using FondApi.Repository.Feedback.Model;

namespace FondApi.Repository.Feedback
{
    public interface IFeedbackRepository
    {
        Task<int> CreateFeedbackAsync(FeedbackDb request);

        Task CreateFeedbackFilesAsync(int feedbackId, string[] filesPaths);
    }
}
