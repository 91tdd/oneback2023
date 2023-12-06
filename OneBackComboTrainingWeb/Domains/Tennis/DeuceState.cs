namespace OneBackComboTrainingWeb.Domains.Tennis;

public class DeuceState : StateBase
{
    public DeuceState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override void NextState()
    {
        GoToAdvState();
    }

    public override string Score()
    {
        return "deuce";
    }
}