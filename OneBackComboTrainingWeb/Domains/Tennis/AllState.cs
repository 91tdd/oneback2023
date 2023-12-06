namespace OneBackComboTrainingWeb.Domains.Tennis;

public class AllState : StateBase
{
    public AllState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override void NextState()
    {
        GoToLookupState();
    }

    public override string Score()
    {
        return $"{_scoreLookup[_tennisBox.GetFirstPlayerScore()]} all";
    }
}