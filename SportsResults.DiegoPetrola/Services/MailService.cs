using Microsoft.Extensions.Options;
using SportsResults.DiegoPetrola.Models;
using System.Net.Mail;

namespace SportsResults.DiegoPetrola.Services;

public class MailService(IOptions<MailOptions> options)
{
    public void SendMail(string body)
    {
        var smtpClient = new SmtpClient("localhost", 25)
        {
            EnableSsl = false // Papercut does not use SSL
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("test@example.com"),
            Subject = "Test Email from .NET",
            Body = "This is a test message intercepted by Papercut.",
            IsBodyHtml = true
        };

        mailMessage.To.Add("recipient@example.com");
        smtpClient.Send(mailMessage);
    }
}