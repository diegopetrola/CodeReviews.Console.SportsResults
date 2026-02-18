using HtmlAgilityPack;
using Microsoft.Playwright;
using SportsResults.DiegoPetrola.Models;

namespace SportsResults.DiegoPetrola.Services;

public class WebScraperService
{
    const string url = "https://www.basketball-reference.com/boxscores/";

    public async Task<List<GameSummary>> ScrapeSite()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();
        var response = await page.GotoAsync(url) ?? throw new HttpRequestException("No response from the server");

        if (response.Status >= 400)
        {
            throw new HttpRequestException($"Site unavailable or invalid request. Status code: {response.StatusText}.");
        }

        var document = new HtmlDocument();
        document.LoadHtml(await page.ContentAsync());

        var matches = new List<GameSummary>();
        var summaries = document.DocumentNode.SelectNodes("//div[contains(@class, 'game_summary')]");

        // Something really strange is happening and the search for class 'game_summary'
        // is returning duplicated (and slightly different) results which forced me to do this weird loop here.
        for (int i = summaries.Count - 1; i >= summaries.Count / 2; i--)
        {
            HtmlNode teams = summaries[i].SelectSingleNode(".//table[2]/tbody");
            var match = new GameSummary
            {
                Team1 = ExtractTeamPerformance(teams.SelectSingleNode(".//tr[1]")),
                Team2 = ExtractTeamPerformance(teams.SelectSingleNode(".//tr[2]"))
            };

            if (match.Team1.TotalScore > match.Team2.TotalScore)
                match.Winner = match.Team1;
            else if (match.Team1.TotalScore > match.Team2.TotalScore)
                match.Winner = match.Team2;

            Console.WriteLine($"{match.Team1.Name}-{match.Team1.TotalScore} VS {match.Team2.Name}-{match.Team2.TotalScore}");
            matches.Add(match);
        }

        return matches;
    }

    private static TeamPerformance ExtractTeamPerformance(HtmlNode teamNode)
    {
        var team = new TeamPerformance
        {
            Name = teamNode.SelectSingleNode(".//a").InnerText
        };

        HtmlNodeCollection rounds = teamNode.SelectNodes("./td[@class='center']");
        foreach (HtmlNode roundScore in rounds)
            team.Score.Add(int.Parse(roundScore.InnerText));

        team.TotalScore = team.Score.Sum();
        return team;
    }
}