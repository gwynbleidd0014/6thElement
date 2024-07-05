using _6thElement.API.infrastructure.Middlewares;
using Microsoft.Extensions.FileProviders;

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
        var RequestPath = string.Format("/{0}", config.GetValue<string>("Constants:ResourcePath"));
        var absolutePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), config.GetValue<string>("Constants:UploadsFolderPath")));

        builder.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(absolutePath),
            RequestPath = RequestPath
        });
    }
}
