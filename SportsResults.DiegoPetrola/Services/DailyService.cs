using Microsoft.Extensions.Hosting;

namespace SportsResults.DiegoPetrola.Services;

public class DailyService(WebScraperService scraperService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new(TimeSpan.FromDays(1));

        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"Scraping started at: {DateTime.Now}");

            var gameSummaries = await scraperService.ScrapeSite();

            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }

        Console.WriteLine($" stoped.");
    }
}