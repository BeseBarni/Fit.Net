using FastEndpoints;
using FitNet.DataAccess;
using FitNet.WebAPI.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment() || Environment.GetEnvironmentVariable("APPLY_MIGRATIONS") == "true")
{
    Console.WriteLine("Waiting for database to be ready...");
    var dbReady = await app.Services.WaitForDatabaseAsync();
    
    if (dbReady)
    {
        await app.Services.ApplyMigrationsAsync();
    }
    else
    {
        Console.WriteLine("WARNING: Could not connect to database. Application may not function correctly.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.UseFastEndpoints();

app.Run();
