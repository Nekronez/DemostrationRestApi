using System.Reflection;
using FondApi.Host.Startup;
using Microsoft.OpenApi.Models;

var config = new ConfigurationBuilder()
        .AddJsonFile("Settings/fondApiSettings.json", optional: false)
        .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices(config);
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Perm capital repair fund site API",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
    });
    app.UseSwaggerUI();
}

app.ConfigurePipelene();

app.Run(Environment.GetEnvironmentVariable("LISTEN_URLS") ?? "http://*:5900");
