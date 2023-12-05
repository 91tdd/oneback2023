namespace OneBackComboTrainingWeb.Domains.Tennis;

public class TennisGame
{
    private int _firstPlayerScore;

    public void AddFirstPlayerScore()
    {
        _firstPlayerScore++;
    }

    public string Score()
    {
        if (_firstPlayerScore == 1)
        {
            return "fifteen love";
        }

        return "love all";
    }
}