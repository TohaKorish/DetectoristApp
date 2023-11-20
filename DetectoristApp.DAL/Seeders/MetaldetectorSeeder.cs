using DetectoristApp.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DetectoristApp.DAL.Seeders;

public class MetaldetectorSeeder
{
    public void Seed(EntityTypeBuilder<Metaldetector> builder)
    {
        var metaldetectors = new List<Metaldetector>
        {
            new Metaldetector { Id = 1, Brand = "Garrett", Model = "Ace 250", Weight = 2.7, IsWaterproof = false, CoilId = 1 },
            new Metaldetector { Id = 2, Brand = "Minelab", Model = "Equinox 800", Weight = 2.96, IsWaterproof = true, CoilId = 2 },
            new Metaldetector { Id = 3, Brand = "Deus", Model = "2", Weight = 2.3, IsWaterproof = false, CoilId = 3 }
        };
        
        builder.HasData(metaldetectors);
    }
}