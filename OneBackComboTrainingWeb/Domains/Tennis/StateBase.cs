namespace OneBackComboTrainingWeb.Domains.Tennis;

public abstract class StateBase
{
    protected readonly Dictionary<int, string> _scoreLookup = new()
                                                              {
                                                                  { 0, "love" },
                                                                  { 1, "fifteen" },
                                                                  { 2, "thirty" },
                                                                  { 3, "forty" },
                                                              };
    protected readonly TennisBox _tennisBox;

    protected StateBase(TennisBox tennisBox)
    {
        _tennisBox = tennisBox;
    }

    public abstract void NextState();
    public abstract string Score();

    protected void GoToAdvState()
    {
        _tennisBox.ChangeState(new AdvState(_tennisBox));
    }

    protected void GoToAllState()
    {
        _tennisBox.ChangeState(new AllState(_tennisBox));
    }

    protected void GoToDeuceState()
    {
        _tennisBox.ChangeState(new DeuceState(_tennisBox));
    }

    protected void GoToLookupState()
    {
        _tennisBox.ChangeState(new LookupState(_tennisBox));
    }

    protected void GoToWinState()
    {
        _tennisBox.ChangeState(new WinState(_tennisBox));
    }
}

public class TennisStateException : Exception
{
    public TennisStateException()
    {
    }

    public TennisStateException(string? message) : base(message)
    {
    }

    public TennisStateException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public TennisBox TennisBox { get; set; }
}