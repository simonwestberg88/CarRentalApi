namespace Application.Exceptions;

public class CarUnavailableException : Exception
{
    public CarUnavailableException()
    {
    }

    public CarUnavailableException(string message) : base(message)
    {
    }
}