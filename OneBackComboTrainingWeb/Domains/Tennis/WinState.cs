namespace OneBackComboTrainingWeb.Domains.Tennis;

public class WinState : StateBase
{
    public WinState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override void NextState()
    {
        throw new TennisStateException(){TennisBox = _tennisBox};
    }

    public override string Score()
    {
        return $"{_tennisBox.GetAdvPlayer()} win";
    }
}