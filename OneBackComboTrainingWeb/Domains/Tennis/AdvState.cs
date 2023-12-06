namespace OneBackComboTrainingWeb.Domains.Tennis;

public class AdvState : StateBase
{
    public AdvState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override void NextState()
    {
        if (_tennisBox.GetFirstPlayerScore() == _tennisBox.GetSecondPlayerScore())
        {
            GoToDeuceState();
        }
        else
        {
            GoToWinState();
        }
    }

    public override string Score()
    {
        return $"{_tennisBox.GetAdvPlayer()} adv";
    }
}