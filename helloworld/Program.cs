using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Handle all HTTP GET requests and respond with "Hello, World!"
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello, World!");
});

app.Run();
