using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FitNet.DataAccess.Context;

public class FitNetContextFactory : IDesignTimeDbContextFactory<FitNetContext>
{
    public FitNetContext CreateDbContext(string[] args)
    {
        string configurationPath = Path.Combine(Directory.GetCurrentDirectory(), "../FitNet.WebAPI");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(configurationPath, "appsettings.json"))
            .Build();

        DbContextOptionsBuilder<FitNetContext> optionsBuilder = new();

        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Could not find a connection string named 'DefaultConnection'.");
        }

        optionsBuilder.UseNpgsql(connectionString);

        return new FitNetContext(optionsBuilder.Options);
    }
}
