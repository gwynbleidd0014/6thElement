using _6thElement.API.infrastructure.Middlewares;
using Microsoft.Extensions.FileProviders;
using System.Runtime.CompilerServices;

namespace _6thElement.API.infrastructure.ConfigureMiddlewares;

public static class ConfigureMiddleware
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<GlobalErrorHandlingMiddleware>();

        return builder;
    }

    public static void UseConfiguredStaticFiles(this IApplicationBuilder builder, IWebHostEnvironment environment, IConfiguration config)
    {
        builder.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(config.GetValue<string>("Constants:UploadsFolderPath")),
            RequestPath = string.Format("/{0}", config.GetValue<string>("Constants:ResourcePath"))
        });
    }
}
