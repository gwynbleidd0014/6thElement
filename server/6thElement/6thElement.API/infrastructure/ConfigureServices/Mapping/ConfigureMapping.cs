using _6thElement.Application.Users;
using _6thElement.Domain.Users;
using Mapster;

namespace _6thElement.API.infrastructure.ConfigureServices.Mapping;

public static class ConfigureMapping
{
    public static IServiceCollection AddMapping(IServiceCollection services)
    {
        TypeAdapterConfig<UserRegisterModel, User>
            .NewConfig();
        TypeAdapterConfig<UserLoginModel, User>
            .NewConfig();

        return services;
    }
}
