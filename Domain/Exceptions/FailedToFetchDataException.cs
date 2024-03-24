namespace Domain.Exceptions;

public class FailedToFetchDataException : Exception
{
    public FailedToFetchDataException()
    {
    }

    public FailedToFetchDataException(string message)
        : base(message)
    {
    }

    public FailedToFetchDataException(string message, Exception inner)
        : base(message, inner)
    {
    }
}