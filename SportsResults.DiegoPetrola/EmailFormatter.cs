using SportsResults.DiegoPetrola.Models;
using System.Text;

namespace SportsResults.DiegoPetrola;

public static class EmailFormatter
{
    public static string GenerateGameReport(List<GameSummary> summaries)
    {
        var sb = new StringBuilder();

        sb.Append("<h2 style='font-family: Arial;'>Basketball Match Summaries</h2>");
        sb.Append("<table border='1' cellpadding='10' style='border-collapse: collapse; font-family: Arial; width: 100%;'>");
        sb.Append("<tr style='background-color: #f2f2f2;'><th>Team 1</th><th>Team 2</th><th>Result</th><th>Winner</th></tr>");

        foreach (var game in summaries)
        {
            string winnerName = game.Winner?.Name ?? "Draw";

            sb.Append("<tr>");
            sb.Append($"<td>{game.Team1.Name} ({game.Team1.TotalScore})</td>");
            sb.Append($"<td>{game.Team2.Name} ({game.Team2.TotalScore})</td>");
            sb.Append($"<td>{game.Team1.TotalScore} - {game.Team2.TotalScore}</td>");
            sb.Append($"<td style='font-weight: bold;'>{winnerName}</td>");
            sb.Append("</tr>");
        }

        sb.Append("</table>");
        return sb.ToString();
    }
}
