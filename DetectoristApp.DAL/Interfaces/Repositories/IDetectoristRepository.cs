using DetectoristApp.DAL.Entities;

namespace DetectoristApp.DAL.Interfaces.Repositories;

public interface IDetectoristRepository : IRepository<Detectorist>
{
    Task<Detectorist> GetByUsernameAsync(string username);

    Task<List<Detectorist>> GetDetectoristsBySexAsync(string sex);

    Task<List<Detectorist>> GetDetectoristsWithWaterproofDetectorAsync();

    Task<List<Detectorist>> GetByMetaldetectorAsync(int id);

    Task<List<Detectorist>> GetByCoilAsync(int id);
}