using _6thElement.API.infrastructure.JwtAuth;
using _6thElement.Application.Accounts;
using _6thElement.Domain.Users;
using _6thElement.Persistance.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _6thElement.API.infrastructure.ConfigureServices;

public static class ApiServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Services
        services.AddTransient<IAccountsService, AccountService>();
        #endregion
        #region Database and Identity
        services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddIdentity<User, IdentityRole>(opts =>
        {
            opts.Password.RequireDigit = true;
        })
           .AddEntityFrameworkStores<AppDbContext>();
        #endregion

        #region Jwt Authorization
        services.AddJwtAuthentification(configuration);
        #endregion

        return services;
    }
}
