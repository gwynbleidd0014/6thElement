using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace _6thElement.API.infrastructure.JwtAuth;

public static class ConfigureJwtAuthentification
{
    public static void AddJwtAuthentification(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(opts =>
            {
                opts.IncludeErrorDetails = true;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = config[$"{nameof(JwtConfig)}:{nameof(JwtConfig.Issuer)}"],
                    ValidateAudience = true,
                    ValidAudience = config[$"{nameof(JwtConfig)}:{nameof(JwtConfig.Audiance)}"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config[$"{nameof(JwtConfig)}:{nameof(JwtConfig.Key)}"])),
                    ValidateLifetime = true,
                };
            });
    }

}
