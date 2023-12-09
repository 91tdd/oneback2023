namespace OneBackComboTrainingWeb.Domains;

public class MatchResult
{
    private string _matchResult;

    public MatchResult(string matchResult)
    {
        _matchResult = matchResult;
    }

    public string GetDisplayScore()
    {
        var homeScore = _matchResult.Count(c => c == 'H');
        var awayScore = "0";
        return $"{homeScore}:{awayScore} (First Half)";
    }

    public string GetResult()
    {
        return _matchResult;
    }

    public void HomeGoal()
    {
        _matchResult += "H";
    }

    public void AwayGoal()
    {
        throw new NotImplementedException();
    }
}