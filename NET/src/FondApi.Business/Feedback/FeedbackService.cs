using FondApi.Business.Email;
using FondApi.Business.Feedback.Model;
using FondApi.Integration.Email.Model;
using FondApi.Repository.Feedback;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FondApi.Business.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepo;
        private readonly IHostingEnvironment _env;
        private readonly IEmailSender _emailSender;

        public FeedbackService(
            IFeedbackRepository feedbackRepo,
            IHostingEnvironment env,
            IEmailSender emailSender)
        {
            _feedbackRepo = feedbackRepo;
            _env = env;
            _emailSender = emailSender;
        }

        public async Task<SendFeedbackResponse> SendFeedbackAsync(
            SendFeedbackRequest request)
        {
            var validation = ValidateSendFeedbackRequest(request);

            if (validation is not null)
            {
                return validation;
            }

            var feedbackId = await _feedbackRepo.CreateFeedbackAsync(request.CreateFeedbackDb());
            
            if (request.Attachment is not null)
            {
                string uploads = Path.Combine(_env.ContentRootPath, "wwwroot", "files");

                Directory.CreateDirectory(Path.Combine(_env.ContentRootPath, "wwwroot", "files"));
                foreach (IFormFile file in request.Attachment)
                {
                    if (file.Length > 0)
                    {
                        string filePath = Path.Combine(uploads, $"{feedbackId}_{file.FileName}");
                        using Stream fileStream = new FileStream(filePath, FileMode.Create);
                        await file.CopyToAsync(fileStream);
                    }
                }

                await _feedbackRepo.CreateFeedbackFilesAsync(
                    feedbackId,
                    request.Attachment.Select(f => Path.Combine("files", $"{feedbackId}_{f.FileName}")).ToArray());
            }

            if(!string.IsNullOrWhiteSpace(request.Email))
            {
                await _emailSender.SendEmailAsync(request.Email, feedbackId);

                string uploads = Path.Combine(_env.ContentRootPath, "wwwroot", "files");
                var messageForFond = new FondEmailMessage
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    Email = request.Email,
                    Phone = request.Phone,
                    Topic = request.Topic,
                    Text = request.Text,
                    Address = new Integration.Email.Model.Address
                    {
                        City = request.Address.City,
                        Street = request.Address.Street,
                        Building = request.Address.Building,
                        Room = request.Address.Room
                    },
                    Attachments = request.Attachment is not null 
                    ? request.Attachment.Select(f => Path.Combine(uploads, $"{feedbackId}_{f.FileName}")).ToArray()
                    : null
                };
                await _emailSender.SendEmailForFondAsync(messageForFond);
            }

            return new SendFeedbackResponse("sent successfully", feedbackId);
        }

        private static SendFeedbackResponse? ValidateSendFeedbackRequest(SendFeedbackRequest request)
        {
            if(request.Email is null && 
                request.Phone is null)
            {
                return new SendFeedbackResponse("phone or email are required");
            }

            if (request.Attachment is not null )
            {
                if (request.Attachment.Any(f => f.Length > 10485760))
                {
                    return new SendFeedbackResponse("one of the files exceeds the size of 10mb");
                }

                var allowedExtensionsEnv = Environment.GetEnvironmentVariable("ALLOWED_EXTENSIONS");
                if (allowedExtensionsEnv is null)
                {
                    throw new Exception("ALLOWED_EXTENSIONS value is not set");
                }
                    
                var allowedExtensions = allowedExtensionsEnv.Split(',');
                if (!request.Attachment.All(f => allowedExtensions.Contains(Path.GetExtension(f.FileName).ToLower())))
                {
                    return new SendFeedbackResponse($"not allowed extension(available: {allowedExtensionsEnv})");
                }
            }

            return null;
        }
    }
}
