namespace SportsResults.DiegoPetrola.Models;

public class GameSummary
{
    public required TeamPerformance Team1;
    public required TeamPerformance Team2;
    public TeamPerformance? Winner;
}
