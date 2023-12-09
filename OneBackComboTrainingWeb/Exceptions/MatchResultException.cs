namespace OneBackComboTrainingWeb.Exceptions;

public class MatchResultException: Exception
{
    public MatchResultException()
    {
    }

    public MatchResultException(string? message) : base(message)
    {
    }

    public MatchResultException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}