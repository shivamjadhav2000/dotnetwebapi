
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMyservice, Myservice>();


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers()
 .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();


// global middleware for handling exceptions

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Global Execption caught: {ex}");
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An Unexpected error occured. Please Try again later.");

    }
    ;
});

app.Use(async(context, next) =>
{
    var myservice= context.RequestServices.GetRequiredService<IMyservice>();
    myservice.logCreation("Middleware 1");
    await next.Invoke();
});


app.MapControllers();

app.Run();




public interface IMyservice {
    void logCreation(string Message);
}


public class Myservice : IMyservice
{
    private readonly int _serviceId;
    public Myservice()
    {
        _serviceId = new Random().Next(10000000, 99999999);
    }
    public void logCreation(string Message)
    {
        Console.WriteLine($"{Message} - Service created with ID: {_serviceId}");
    }
}


