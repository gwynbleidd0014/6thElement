using _6thElement.API.infrastructure.Middlewares;
using System.Runtime.CompilerServices;

namespace _6thElement.API.infrastructure.ConfigureMiddlewares;

public static class ConfigureMiddleware
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<GlobalErrorHandlingMiddleware>();

        return builder;
    }
}
