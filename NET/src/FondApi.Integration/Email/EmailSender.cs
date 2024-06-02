using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using FondApi.Integration.Email.Model;

namespace FondApi.Business.Email;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;

    public EmailSender(
        IOptions<EmailConfiguration> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public async Task SendEmailAsync(string to, int feedbackId)
    {
        var emailMessage = CreateEmailMessage(to, _emailConfig.Content.Replace("{feedback_id}", feedbackId.ToString()));
        await Send(emailMessage);
    }

    public async Task SendEmailForFondAsync(FondEmailMessage message)
    {
        var content = @$"
                        Имя: {message.FirstName}
                        Фамилия: {message.LastName} 
                        Отчество: {message.MiddleName} 
                        Email: {message.Email}
                        Телефон: {message.Phone} 
                        Тема: {message.Topic}
                        Текст: {message.Text} 
                        Адрес: 
                        Город: {message.Address.City} 
                        Улица: {message.Address.Street} 
                        Дом: {message.Address.Building} 
                        Квартира: {message.Address.Room}";

        await Send(CreateEmailMessageForFond(content, message.Attachments));
    }

    private MimeMessage CreateEmailMessage(string to, string content)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Fond59", _emailConfig.From));
        emailMessage.To.Add(new MailboxAddress("Получатель", to));
        emailMessage.Subject = _emailConfig.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = content };
        return emailMessage;
    }

    private MimeMessage CreateEmailMessageForFond(string content, IEnumerable<string> attachments)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Fond59", _emailConfig.From));
        emailMessage.To.Add(new MailboxAddress("Получатель", _emailConfig.To));
        emailMessage.Subject = _emailConfig.Subject;

        var body = new TextPart(MimeKit.Text.TextFormat.Text) 
        { 
            Text = content 
        };

        var multipart = new Multipart("mixed");
        multipart.Add(body);

        if (attachments != null)
        {
            foreach (var path in attachments)
            {
                multipart.Add(new MimePart()
                {
                    Content = new MimeContent(File.OpenRead(path), ContentEncoding.Default),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(path)
                });
            }
        }
        emailMessage.Body = multipart;

        return emailMessage;
    }

    private async Task Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();

        try
        {
            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
            await client.SendAsync(mailMessage);
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
    }
}