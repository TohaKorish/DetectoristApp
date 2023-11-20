using DetectoristApp.DAL.Configurations;
using DetectoristApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DetectoristApp.DAL.Data;

public class DetectoristDbContext : DbContext
{
    public DbSet<Detectorist> Detectorists { get; set; }

    public DbSet<Metaldetector> Metaldetectors { get; set; }

    public DbSet<Coil> Coils { get; set; }

    public DetectoristDbContext(DbContextOptions<DetectoristDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DetectoristConfiguration());
        modelBuilder.ApplyConfiguration(new MetaldetectorConfiguration());
        modelBuilder.ApplyConfiguration(new CoilConfiguration());
    }
}