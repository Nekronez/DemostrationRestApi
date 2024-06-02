using FondApi.Business.Feedback.Model;

namespace FondApi.Business.Feedback
{
    public interface IFeedbackService
    {
        Task<SendFeedbackResponse> SendFeedbackAsync(SendFeedbackRequest request);
    }
}
