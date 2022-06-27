using Microsoft.AspNetCore.Mvc.Infrastructure;
using ServiceLifetimeExample;
using Microsoft.Extensions.Hosting;
using ServiceLifetimeExample.Intrastructure;
//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
{
//    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();

using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
    .SetMinimumLevel(LogLevel.Trace)
    .AddConsole());
ILogger logger = loggerFactory.CreateLogger<Program>();




var builder = WebApplication.CreateBuilder(args);

var x = builder.Host;




var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build();

var provider=app.Services.GetRequiredService <IActionDescriptorCollectionProvider> ();
var controllerActionDescriptors = provider
         .ActionDescriptors
         .Items
         .OfType<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>().FirstOrDefault();

startup.Configure(app, app.Environment);

EndpointInfo.getpages(app);


if (app.Environment.IsDevelopment())
{
    app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));
}
app.Run();