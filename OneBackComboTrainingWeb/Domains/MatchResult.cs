#region

using OneBackComboTrainingWeb.Exceptions;

#endregion

namespace OneBackComboTrainingWeb.Domains;

public class MatchResult
{
    private string _matchResult;

    public MatchResult(string matchResult)
    {
        _matchResult = matchResult;
    }

    public void AwayGoal()
    {
        _matchResult += "A";
    }

    public void CancelHomeGoal()
    {
        if (_matchResult.EndsWith('H'))
        {
            _matchResult = _matchResult[..^1];
        }
        else
        {
            throw new MatchResultException() { MatchResult = this };
        }
    }

    public string GetDisplayScore()
    {
        var homeScore = _matchResult.Count(c => c == 'H');
        var awayScore = _matchResult.Count(c => c == 'A');
        var period = _matchResult.Contains(";") ? "Second" : "First";
        return $"{homeScore}:{awayScore} ({period} Half)";
    }

    public string GetResult()
    {
        return _matchResult;
    }

    public void HomeGoal()
    {
        _matchResult += "H";
    }

    public void NextPeriod()
    {
        _matchResult += ";";
    }
}