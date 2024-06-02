using FondApi.Integration.Email.Model;
using FondApi.Repository.Feedback.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FondApi.Business.Feedback.Model
{
    public class SendFeedbackRequest
    {
        [Required]
        public string? LastName { get; init; }

        [Required]
        public string? FirstName { get; init; }

        public string? MiddleName { get; init; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "email is invalid")]
        public string? Email { get; init; }

        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "phone is invalid")]
        public string? Phone { get; init; }

        [Required]
        public string? Topic { get; init; }

        [Required]
        public string? Text { get; init; }

        public Address? Address { get; init; }

        public IFormFile[]? Attachment { get; init; }

        public FeedbackDb CreateFeedbackDb()
        {
            return new FeedbackDb
            {
                LastName = this.LastName,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                Email = this.Email,
                Phone = this.Phone,
                Topic = this.Topic,
                Text = this.Text,
                City = this.Address?.City,
                Street = this.Address?.Street,
                Building = this.Address?.Building,
                Room = this.Address?.Room,
            };
        }
    }
}
