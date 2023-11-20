using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DetectoristApp.DAL.Data.Repositories;

public class MetaldetectorRepository : Repository<Metaldetector>, IMetaldetectorRepository
{
    public MetaldetectorRepository(DbContext context) : base(context)
    {
    }
    
}