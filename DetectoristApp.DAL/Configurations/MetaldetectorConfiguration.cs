using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DetectoristApp.DAL.Configurations;

public class MetaldetectorConfiguration : IEntityTypeConfiguration<Metaldetector>
{
    public void Configure(EntityTypeBuilder<Metaldetector> builder)
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
        
        builder.Property(m => m.Weight)
            .HasColumnType("double")
            .IsRequired();
        
        builder.Property(m => m.IsWaterproof)
            .HasColumnType("tinyint(1)")
            .IsRequired();

        builder.HasOne(m => m.Coil)
            .WithMany(c => c.Metaldetectors)
            .HasForeignKey(m => m.CoilId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        new MetaldetectorSeeder().Seed(builder);
    }
}