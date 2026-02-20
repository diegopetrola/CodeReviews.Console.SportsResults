using Microsoft.Extensions.Options;
using SportsResults.DiegoPetrola.Models;
using System.Net.Mail;

namespace SportsResults.DiegoPetrola.Services;

public class MailService(IOptions<MailOptions> options)
{
    public void SendMail(string body)
    {
        var smtpClient = new SmtpClient(options.Value.Host, options.Value.Port)
        {
            EnableSsl = options.Value.UseSsl
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(options.Value.From),
            Subject = options.Value.Subject,
            Body = body,
            IsBodyHtml = true,
        };

        mailMessage.To.Add(options.Value.To);
        smtpClient.Send(mailMessage);
    }
}