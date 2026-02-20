namespace SportsResults.DiegoPetrola.Models;

public class MailOptions
{
    public int Port { get; set; }
    public bool UseSsl { get; set; }
    public string Host { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
}
