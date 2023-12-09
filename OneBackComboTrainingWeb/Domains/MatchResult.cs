#region

using OneBackComboTrainingWeb.Enums;
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

    public void UpdateBy(Event @event)
    {
        switch (@event)
        {
            case Event.HomeGoal:
                HomeGoal();
                break;
            case Event.AwayGoal:
                AwayGoal();
                break;
            case Event.NextPeriod:
                NextPeriod();
                break;
            case Event.CancelHomeGoal:
                CancelHomeGoal();
                break;
            case Event.CancelAwayGoal:
                CancelAwayGoal();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
        }
    }

    private void AwayGoal()
    {
        _matchResult += "A";
    }

    private void CancelAwayGoal()
    {
        CancelGoal('A');
    }

    private void CancelGoal(char score)
    {
        var isNextPeriod = false;
        if (_matchResult.EndsWith(';'))
        {
            isNextPeriod = true;
            _matchResult = _matchResult[..^1];
        }

        if (!_matchResult.EndsWith(score))
        {
            throw new MatchResultException() { MatchResult = this };
        }

        _matchResult = _matchResult[..^1] + (isNextPeriod ? ";" : "");
    }

    private void CancelHomeGoal()
    {
        CancelGoal('H');
    }

    private void HomeGoal()
    {
        _matchResult += "H";
    }

    private void NextPeriod()
    {
        _matchResult += ";";
    }
}