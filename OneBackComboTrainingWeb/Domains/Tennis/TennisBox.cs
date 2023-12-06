namespace OneBackComboTrainingWeb.Domains.Tennis;

public class TennisBox
{
    private readonly string _firstPlayerName;
    private readonly string _secondPlayerName;
    private StateBase _currentState;
    private int _firstPlayerScore;
    private int _secondPlayerScore;

    public TennisBox(string firstPlayerName, string secondPlayerName)
    {
        _currentState = new AllState(this);
        _firstPlayerName = firstPlayerName;
        _secondPlayerName = secondPlayerName;
    }

    public void ChangeState(StateBase state)
    {
        _currentState = state;
    }

    public void FirstPlayerGoal()
    {
        _firstPlayerScore++;
        _currentState.NextState();
    }

    public string GetAdvPlayer()
    {
        return GetFirstPlayerScore() > GetSecondPlayerScore()
            ? _firstPlayerName
            : _secondPlayerName;
    }

    public int GetFirstPlayerScore()
    {
        return _firstPlayerScore;
    }

    public int GetSecondPlayerScore()
    {
        return _secondPlayerScore;
    }

    public string Score()
    {
        return _currentState.Score();
    }

    public void SecondPlayerGoal()
    {
        _secondPlayerScore++;
        _currentState.NextState();
    }
}