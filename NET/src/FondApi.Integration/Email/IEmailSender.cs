using FondApi.Integration.Email.Model;

namespace FondApi.Business.Email;

public interface IEmailSender
{
    Task SendEmailAsync(string to, int feedbackId);

    Task SendEmailForFondAsync(FondEmailMessage messageForFond);
}
