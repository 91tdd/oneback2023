namespace OneBackComboTrainingWeb.Domains.Tennis;

public class TennisGame
{
    private readonly string _firstPlayerName;
    private readonly Dictionary<int, string> _scoreLookup = new()
                                                            {
                                                                { 0, "love" },
                                                                { 1, "fifteen" },
                                                                { 2, "thirty" },
                                                                { 3, "forty" },
                                                            };
    private readonly string _secondPlayerName;
    private int _firstPlayerScore;
    private int _secondPlayerScore;

    public TennisGame(string firstPlayerName, string secondPlayerName)
    {
        _firstPlayerName = firstPlayerName;
        _secondPlayerName = secondPlayerName;
    }

    public void AddFirstPlayerScore()
    {
        _firstPlayerScore++;
    }

    public void AddSecondPlayerScore()
    {
        _secondPlayerScore++;
    }

    public string Score()
    {
        if (IsSameScore())
        {
            if (_firstPlayerScore >= 3)
            {
                return DeuceScore();
            }

            return AllScore();
        }

        if (_firstPlayerScore <= 3 && _secondPlayerScore <= 3)
        {
            return LookupScore();
        }

        if (IsAdv())
        {
            return $"{GetAdvPlayer()} adv";
        }

        return $"{GetAdvPlayer()} win";
    }

    private static string DeuceScore()
    {
        return "deuce";
    }

    private string AllScore()
    {
        return $"{_scoreLookup[_firstPlayerScore]} all";
    }

    private string GetAdvPlayer()
    {
        return _firstPlayerScore > _secondPlayerScore
            ? _firstPlayerName
            : _secondPlayerName;
    }

    private bool IsAdv()
    {
        return Math.Abs(_firstPlayerScore - _secondPlayerScore) == 1;
    }

    private bool IsSameScore()
    {
        return _firstPlayerScore == _secondPlayerScore;
    }

    private string LookupScore()
    {
        return $"{_scoreLookup[_firstPlayerScore]} {_scoreLookup[_secondPlayerScore]}";
    }
}