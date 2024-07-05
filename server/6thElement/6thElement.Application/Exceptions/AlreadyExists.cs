namespace _6thElement.Application.Exceptions;

public class AlreadyExists : Exception, ICustomException, IAlreadyExists
{
    public AlreadyExists(string? message) : base(message)
    {
    }
}
