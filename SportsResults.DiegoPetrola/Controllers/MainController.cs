using SportsResults.DiegoPetrola.Services;

namespace SportsResults.DiegoPetrola.Controllers;

internal class MainController(WebScraperService scraperService)
{
    public async Task Start()
    {
        await scraperService.ScrapeSite();
    }
}
