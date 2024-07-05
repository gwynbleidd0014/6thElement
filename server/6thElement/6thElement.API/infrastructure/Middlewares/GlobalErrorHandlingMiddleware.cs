using _6thElement.API.infrastructure.ErrorHandler;

namespace _6thElement.API.infrastructure.Middlewares;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var problem = new GlobalErrorHandler(httpContext, ex);
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
