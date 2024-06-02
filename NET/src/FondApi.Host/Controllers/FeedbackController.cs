using FondApi.Business.Feedback;
using FondApi.Business.Feedback.Model;
using FondApi.Host.Extenstions.ExceptionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace FondApi.Host.Controllers
{
    /// <summary>
    /// FeedbackController
    /// </summary>
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="feedbackService"></param>
        public FeedbackController(
            IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        /// <summary>
        /// Создание обращения
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/feedback")]
        [ProducesResponseType(typeof(SendFeedbackResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendFeedbackAsync([FromForm] SendFeedbackRequest request)
            => Ok(await _feedbackService.SendFeedbackAsync(request));
    }
}
