using _6thElement.Application.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _6thElement.API.infrastructure.ErrorHandler;

public class GlobalErrorHandler : ProblemDetails
{
    public GlobalErrorHandler(HttpContext context, Exception ex)
    {
        Extensions["TraceId"] = context.TraceIdentifier;
        Instance = context.Request.Path;
        Title = "Something Went Wrong";
        if (ex is ICustomException)
        {
            HandleCustomException(ex);
        }
        else
        {
            HandleException(ex);
        }

    }

    private void HandleException(Exception ex)
    {
        Status = StatusCodes.Status500InternalServerError;
        Type = @"https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        Detail = "Something Went Wrong";
    }

    private void HandleCustomException(Exception ex)
    {
        Detail = ex.Message;

        if (ex is INotFound)
            HandleNotFounds(ex);
        if (ex is IAlreadyExists)
            HandleAlreadyExists(ex);

    }

    private void HandleNotFounds(Exception ex)
    {
        Status = StatusCodes.Status404NotFound;
        Type = @"https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
    }

    private void HandleAlreadyExists(Exception ex)
    {
        Status = StatusCodes.Status409Conflict;
        Type = @"https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
    }
}
