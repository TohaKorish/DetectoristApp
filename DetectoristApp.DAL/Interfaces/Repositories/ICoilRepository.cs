using DetectoristApp.DAL.Entities;

namespace DetectoristApp.DAL.Interfaces.Repositories;

public interface ICoilRepository : IRepository<Coil>
{
    Task<List<Coil>> GetByBrandAsync(string brand);
    
    Task<Coil> GetByBrandAndModelAsync(string brand, string model);
}