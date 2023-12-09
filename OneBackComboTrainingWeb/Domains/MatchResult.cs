namespace OneBackComboTrainingWeb.Domains;

public class MatchResult
{
    private readonly string _matchResult;

    public MatchResult(string matchResult)
    {
        _matchResult = matchResult;
    }

    public void HomeGoal()
    {
        throw new NotImplementedException();
    }

    public string GetDisplayScore()
    {
        var homeScore = "1";
        var awayScore = "0";
        return $"{homeScore}:{awayScore} (First Half)";
    }
}