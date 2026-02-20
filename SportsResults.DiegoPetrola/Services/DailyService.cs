using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SportsResults.DiegoPetrola.Services;

public class DailyService(IServiceProvider services, ILogger<DailyService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new(TimeSpan.FromDays(1));

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                logger.LogInformation("Scheduled task started.");
                using var scope = services.CreateScope();

                var scraper = scope.ServiceProvider.GetRequiredService<WebScraperService>();
                var mailer = scope.ServiceProvider.GetRequiredService<MailService>();

                var gameSummaries = await scraper.ScrapeSite();
                var report = EmailFormatter.GenerateGameReport(gameSummaries);

                mailer.SendMail(report);
                logger.LogInformation("Email sent successfully.");

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while scraping.");
            }

            await timer.WaitForNextTickAsync(stoppingToken);
        }
    }
}
