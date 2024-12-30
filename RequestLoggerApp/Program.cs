using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Custom Middleware to log HTTP requests
app.Use(async (context, next) =>
{
    // Log Request Information
    Console.WriteLine($"HTTP Request: {context.Request.Method} {context.Request.Path}");

    // Continue to the next middleware
    await next.Invoke();

    // Log Response Information
    Console.WriteLine($"HTTP Response: {context.Response.StatusCode}");
});

// Endpoint to return a custom response
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Welcome! Your request has been logged.");
});

app.Run();
