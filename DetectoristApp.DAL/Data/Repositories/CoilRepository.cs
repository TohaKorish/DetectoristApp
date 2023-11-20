using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DetectoristApp.DAL.Data.Repositories;

public class CoilRepository : Repository<Coil>, ICoilRepository
{
    public CoilRepository(DbContext context) : base(context)
    {
    }
    
}