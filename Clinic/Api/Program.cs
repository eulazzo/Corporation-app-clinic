using Api.Configurations;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Configuration for serilog

IConfigurationRoot configuration = GetConfiguration();

ConfigureLog(configuration);

builder.Host.UseSerilog();

//try
//{
//    Log.Information("WepApi Started!");
//}
//catch (Exception ex)
//{
//    Log.Fatal(ex, "Erro Catastrófico");
//}
//finally
//{
//    Log.CloseAndFlush();
//}




//Adiciona nas injecçoes de dependencias dos controllers e do popline quando entrar no controller
builder.Services.AddControllers();
builder.Services.AddFluentValidationConfiguration();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

builder.Services.AddJwtTConfiguration(configuration);

builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddAutoMapperConfiguration();

builder.Services.AddDataBaseConfiguration(configuration);

    var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}
app.UseHttpsRedirection();

app.UseDataBaseConfiguration();

app.UseAuthorization();
app.UseJwtConfiguration();
app.MapControllers();

app.Run();

static IConfigurationRoot GetConfiguration()
{
    string enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{enviroment}.json")
        .Build();
    return configuration;
}

static void ConfigureLog(IConfigurationRoot configuration)
{
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}