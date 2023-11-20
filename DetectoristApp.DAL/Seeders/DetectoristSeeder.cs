using DetectoristApp.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DetectoristApp.DAL.Seeders;

public class DetectoristSeeder
{
    public void Seed(EntityTypeBuilder<Detectorist> builder)
    {
        var detectorists = new List<Detectorist>
        {
            new Detectorist { Id = 1, Username = "Kola1", Age = 25, Sex = "Male", MetaldetectorId = 1 },
            new Detectorist { Id = 2, Username = "Kola2", Age = 30, Sex = "Female", MetaldetectorId = 2 },
            new Detectorist { Id = 3, Username = "Halk", Age = 40, Sex = "Male", MetaldetectorId = 3 }
        };
        
        builder.HasData(detectorists);
    }
}