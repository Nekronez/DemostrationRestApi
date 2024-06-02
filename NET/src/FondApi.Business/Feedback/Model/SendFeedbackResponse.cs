namespace FondApi.Business.Feedback.Model
{
    public class SendFeedbackResponse
    {
        public SendFeedbackResponse(string message, int? id = null)
        {
            Id = id;
            Message = message;
        }

        public int? Id { get; init; }

        public string? Message { get; init; }
    }
}
