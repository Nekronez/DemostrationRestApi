using FondApi.Business.Feedback;
using FondApi.Business.Feedback.Model;
using FondApi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace FondApi.Host.Test.Feedback
{
    public class FeedbackControllerTests
    {
        private readonly IFeedbackService _feedbackService;
        private readonly FeedbackController _controller;

        public FeedbackControllerTests()
        {
            _feedbackService = Substitute.For<IFeedbackService>();
            _controller = new FeedbackController(_feedbackService);
        }

        [Fact]
        public async void SendFeedback_Success()
        {
            // Arrange
            var requestSend = new SendFeedbackRequest()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "Email1",
                Text = "Text1",
                Topic = "Topic1"
            };
            var responseSend = new SendFeedbackResponse("sent successfully", 0);

            _feedbackService.SendFeedbackAsync(Arg.Any<SendFeedbackRequest>()).Returns(responseSend);

            // Act
            var response = await _controller.SendFeedbackAsync(requestSend);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
