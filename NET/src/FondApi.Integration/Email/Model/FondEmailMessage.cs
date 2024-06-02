namespace FondApi.Integration.Email.Model;
    public class FondEmailMessage
    {
        public string? LastName { get; init; }

        public string? FirstName { get; init; }

        public string? MiddleName { get; init; }

        public string? Email { get; init; }

        public string? Phone { get; init; }

        public string? Topic { get; init; }

        public string? Text { get; init; }

        public Address? Address { get; init; }

        public IEnumerable<string>? Attachments { get; set; }
    }
