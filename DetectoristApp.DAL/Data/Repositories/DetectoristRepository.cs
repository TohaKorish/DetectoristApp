using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DetectoristApp.DAL.Data.Repositories;

public class DetectoristRepository : Repository<Detectorist>, IDetectoristRepository
{
    public DetectoristRepository(DbContext context) : base(context)
    {
    }
    
    public async Task<Detectorist> GetByUsernameAsync(string username)
    {
        return await DbSet.FirstOrDefaultAsync(d => d.Username == username);
    }
    
    public async Task<List<Detectorist>> GetDetectoristsBySexAsync(string sex)
    {
        return await DbSet.Where(d => d.Sex == sex).ToListAsync();
    }
    
    public async Task<List<Detectorist>> GetDetectoristsWithWaterproofDetectorAsync()
    {
        return await DbSet.Where(d => d.Metaldetector.IsWaterproof).ToListAsync();
    }
    
    public async Task<List<Detectorist>> GetByMetaldetectorAsync(int id)
    {
        return await DbSet.Where(d => d.Metaldetector.Id == id ).ToListAsync();
    }
    
    public async Task<List<Detectorist>> GetByCoilAsync(int id)
    {
        return await DbSet.Where(d => d.Metaldetector.Id == id ).ToListAsync();
    }
    
    
}