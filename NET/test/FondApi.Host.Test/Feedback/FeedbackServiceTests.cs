using FondApi.Business.Email;
using FondApi.Business.Feedback;
using FondApi.Business.Feedback.Model;
using FondApi.Repository.Feedback;
using FondApi.Repository.Feedback.Model;
using Microsoft.AspNetCore.Hosting;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.Feedback;

public class FeedbackServiceTests
{
    private readonly IFeedbackRepository _feedbackRepo;
    private readonly IHostingEnvironment _env;
    private readonly FeedbackService _service;

    public FeedbackServiceTests()
    {
        _feedbackRepo = Substitute.For<IFeedbackRepository>();
        _env = Substitute.For<IHostingEnvironment>();
        var email = Substitute.For<IEmailSender>();
       
        _service = new FeedbackService(_feedbackRepo, _env, email);
    }

    [Fact]
    public async void SendFeedbackAsync_Success()
    {
        // Arrange
        var requestSend = new SendFeedbackRequest()
        {
            FirstName = "FirstName1",
            LastName = "LastName1",
            Email = "Email1",
            Text = "Text1",
            Topic = "Topic1",
        };;

        _feedbackRepo.CreateFeedbackAsync(Arg.Any<FeedbackDb>()).Returns(1);

        // Act
        var response = await _service.SendFeedbackAsync(requestSend);

        // Assert
        Assert.IsAssignableFrom<SendFeedbackResponse>(response);
        Assert.Equal("sent successfully", response.Message);
        Assert.Equal(1, response.Id);
        await _feedbackRepo.Received(1).CreateFeedbackAsync(Arg.Any<FeedbackDb>());
        await _feedbackRepo.Received(0).CreateFeedbackFilesAsync(Arg.Any<int>(), Arg.Any<string[]>());
    }
}
