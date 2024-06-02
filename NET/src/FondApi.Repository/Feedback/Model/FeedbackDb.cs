namespace FondApi.Repository.Feedback.Model
{
    public class FeedbackDb
    {
        public int? Id { get; set; }

        public string? LastName { get; init; }

        public string? FirstName { get; init; }

        public string? MiddleName { get; init; }

        public string? Email { get; init; }

        public string? Phone { get; init; }

        public string? Topic { get; init; }

        public string? Text { get; init; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Building { get; set; }

        public string? Room { get; set; }
    }
}
