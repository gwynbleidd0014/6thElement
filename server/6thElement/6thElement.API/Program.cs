using _6thElement.API.infrastructure.ConfigureMiddlewares;
using _6thElement.API.infrastructure.ConfigureServices;
using _6thElement.API.infrastructure.JwtAuth;
using _6thElement.API.infrastructure.Seeding;
using Serilog;


try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Full setup of serilog. We read log settings from appsettings.json
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services));


    builder.Services.AddControllers();


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    builder.Services.AddConfiguredSwagger();
    builder.Services.AddCustomValidation();
    builder.Services.AddDbContextAndIdentity(builder.Configuration);
    builder.Services.AddJwtAuthentification(builder.Configuration);
    builder.Services.AddServices(builder.Configuration);


    var app = builder.Build();

    app.Services.Seed();

    app.UseMiddlewares();


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }



    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseConfiguredStaticFiles(builder.Environment, builder.Configuration);
    app.MapControllers();

    app.Run("http://0.0.0.0:8080");
}

catch (Exception ex)
{
    Log.Logger.Fatal(ex.Message);
}