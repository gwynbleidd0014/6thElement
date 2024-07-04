using _6thElement.API.infrastructure.JwtAuth;
using _6thElement.Application.Accounts;
using _6thElement.Application.Answers;
using _6thElement.Application.Chapters;
using _6thElement.Application.Modules;
using _6thElement.Application.Questions;
using _6thElement.Domain.Users;
using _6thElement.Infrastructure;
using _6thElement.Persistance.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _6thElement.API.infrastructure.ConfigureServices;

public static class ApiServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Services
        services.AddScoped<IAccountsService, AccountService>();

        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IModuleService, ModuleService>();

        services.AddScoped<IChapterRepository, ChapterRepository>();
        services.AddScoped<IChapterService, ChapterService>();

        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionService, QuestionService>();

        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<IAnswerService, AnswerService>();
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
