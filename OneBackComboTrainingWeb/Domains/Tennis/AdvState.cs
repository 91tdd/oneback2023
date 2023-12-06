namespace OneBackComboTrainingWeb.Domains.Tennis;

public class AdvState : StateBase
{
    public AdvState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override void NextState()
    {
        throw new NotImplementedException();
    }

    public override string Score()
    {
        var advPlayer = GetAdvPlayer();
        return $"{advPlayer} adv";
    }

    private string GetAdvPlayer()
    {
        return _tennisBox.GetFirstPlayerScore() > _tennisBox.GetSecondPlayerScore()
            ? _tennisBox.GetFirstPlayerName()
            : _tennisBox.GetSecondPlayerName();
    }
}