using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondApi.Business.Email.Model;

public class UserEmailMessage
{
    public List<MailboxAddress> To { get; init; }

    public string Subject { get; init; }

    public string Content { get; init; }

    public UserEmailMessage(string to, string subject, string content)
    {
        To = new List<MailboxAddress>();
        To.Add(new MailboxAddress("Получатель", to));
        Subject = subject;
        Content = content;
    }
}
