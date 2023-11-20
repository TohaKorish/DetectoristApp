using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DetectoristApp.DAL.Configurations;

public class DetectoristConfiguration : IEntityTypeConfiguration<Detectorist>
{
    public void Configure(EntityTypeBuilder<Detectorist> builder)
    {
        builder.Property(d => d.Id)
            .UseMySqlIdentityColumn()
            .IsRequired();

        builder.Property(d => d.Username)
            .HasColumnType("varchar(100)")
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(d => d.Username)
            .IsUnique();

        builder.Property(d => d.Age)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(d => d.Sex)
            .HasColumnType("varchar(8)")
            .IsRequired()
            .HasMaxLength(8);
        
        builder.HasOne(d => d.Metaldetector)
            .WithMany(m => m.Detectorists)
            .HasForeignKey(d => d.MetaldetectorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        new DetectoristSeeder().Seed(builder);
    }
}