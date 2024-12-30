using Microsoft.AspNetCore.Builder; // Required for building the app
using Microsoft.Extensions.DependencyInjection; // Required for adding services

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Adds MVC framework support for controllers and views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware to serve static files (e.g., CSS, JS)
app.UseStaticFiles();

// Middleware to route incoming HTTP requests
app.UseRouting();

// Endpoint configuration to map controllers
app.UseEndpoints(endpoints =>
{
    // Default route: {controller=Home}/{action=Index}/{id?}
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// Start the application
app.Run();
