using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DetectoristApp.DAL.Configurations;

public class CoilConfiguration : IEntityTypeConfiguration<Coil>
{
    public void Configure(EntityTypeBuilder<Coil> builder)
    {
        builder.Property(m => m.Id)
            .UseMySqlIdentityColumn()
            .IsRequired();
        
        builder.Property(m => m.Brand)
            .HasColumnType("varchar(50)")
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(m => m.Model)
            .HasColumnType("varchar(50)")
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(m => m.Diameter)
            .HasColumnType("double")
            .IsRequired();
        
        new CoilSeeder().Seed(builder);
    }
}