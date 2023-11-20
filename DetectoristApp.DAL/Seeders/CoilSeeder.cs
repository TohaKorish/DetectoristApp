using DetectoristApp.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DetectoristApp.DAL.Seeders;

public class CoilSeeder
{
    public void Seed(EntityTypeBuilder<Coil> builder)
    {
        var coils = new List<Coil>
        {
            new Coil { Id = 1, Brand = "Nel", Model = "Tornado", Diameter = 6.5 },
            new Coil { Id = 2, Brand = "Minelab", Model = "EQX 15 Double-D", Diameter = 11 },
            new Coil { Id = 3, Brand = "Deus", Model = "9'' FMF", Diameter = 9 }
        };
        
        builder.HasData(coils);
    }
}