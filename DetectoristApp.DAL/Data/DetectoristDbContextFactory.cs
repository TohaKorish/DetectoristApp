using DetectoristApp.DAL.Configurations;
using DetectoristApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DetectoristApp.DAL.Data;

public class DetectoristDbContextFactory : IDesignTimeDbContextFactory<DetectoristDbContext>
{
    public DetectoristDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DetectoristDbContext>();
 
        var conf = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DetectoristApp"))
            .AddJsonFile("appsettings.json")
            .Build();
 
        string connectionString = conf.GetConnectionString("DefaultConnection");
        if (connectionString != null)
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new DetectoristDbContext(optionsBuilder.Options);
    }
}