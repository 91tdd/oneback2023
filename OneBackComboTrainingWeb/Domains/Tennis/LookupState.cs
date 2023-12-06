namespace OneBackComboTrainingWeb.Domains.Tennis;

public class LookupState : StateBase
{
    public LookupState(TennisBox tennisBox) : base(tennisBox)
    {
    }

    public override void NextState()
    {
        if (_tennisBox.GetFirstPlayerScore() == _tennisBox.GetSecondPlayerScore())
        {
            if (_tennisBox.GetFirstPlayerScore() >= 3)
            {
                GoToDeuceState();
            }
            else
            {
                GoToAllState();
            }
        }
        else
        {
            GoToLookupState();
        }
    }

    public override string Score()
    {
        return $"{_scoreLookup[_tennisBox.GetFirstPlayerScore()]} {_scoreLookup[_tennisBox.GetSecondPlayerScore()]}";
    }
}