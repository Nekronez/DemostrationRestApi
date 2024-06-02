namespace FondApi.Business.Email;

public class EmailConfiguration
{
    public string From { get; init; } = default!;

    public string SmtpServer { get; init; } = default!;

    public int Port { get; set; }

    public string UserName { get; init; } = default!;

    public string Password { get; init; } = default!;

    public string Subject { get; init; } = default!;

    public string Content { get; init; } = default!;

    public string To { get; init; } = default!;
}
