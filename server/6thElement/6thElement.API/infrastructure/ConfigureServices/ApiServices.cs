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
using Microsoft.OpenApi.Models;

namespace _6thElement.API.infrastructure.ConfigureServices;

public static class ApiServices
{

    public static IServiceCollection AddDbContextAndIdentity(this IServiceCollection services, IConfiguration configuration, ServiceLifetime contextLifeTime = ServiceLifetime.Scoped)
    {

        services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), contextLifetime: contextLifeTime);
        services.AddIdentity<User, Role>(opts =>
        {
            opts.Password.RequireDigit = true;
        })
           .AddRoles<Role>()
           .AddEntityFrameworkStores<AppDbContext>();

        return services;
    }

    public static void AddConfiguredSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opts =>
        {
            opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Description = "Authorization for Forum Api"
            });

            opts.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            opts.SwaggerDoc("v1", new OpenApiInfo() { Title = "Forum Api", Version = "1.0" });
        });
    }

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
        #endregion


        return services;
    }
}
