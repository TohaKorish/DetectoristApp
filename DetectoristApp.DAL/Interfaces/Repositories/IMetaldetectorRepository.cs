using DetectoristApp.DAL.Entities;

namespace DetectoristApp.DAL.Interfaces.Repositories;

public interface IMetaldetectorRepository : IRepository<Metaldetector>
{
    Task<List<Metaldetector>> GetByBrandAsync(string brand);
    
    Task<Metaldetector> GetByBrandAndModelAsync(string brand, string model);
}