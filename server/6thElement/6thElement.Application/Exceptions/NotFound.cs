namespace _6thElement.Application.Exceptions;

public class NotFound : Exception, ICustomException, INotFound
{
    public NotFound(string? message) : base(message)
    {
    }
}
