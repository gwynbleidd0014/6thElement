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
        HandleException(ex);
    }

    private void HandleException(Exception ex)
    {
        Status = StatusCodes.Status500InternalServerError;
        Type = @"https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        Detail = ex.Message;
    }

}
