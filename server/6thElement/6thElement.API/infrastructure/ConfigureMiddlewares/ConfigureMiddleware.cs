﻿using _6thElement.API.infrastructure.Middlewares;
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


        builder.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = (context) =>
            {
                if (!context.Context.User.Identity.IsAuthenticated && context.Context.Request.Path.StartsWithSegments(RequestPath))
                {
                    throw new Exception("Not authenticated");
                }
            },
            FileProvider = new PhysicalFileProvider(config.GetValue<string>("Constants:UploadsFolderPath")),
            RequestPath = RequestPath
        });
    }
}
