using DetectoristApp.DAL.Interfaces;
using DetectoristApp.DAL.Interfaces.Repositories;

namespace DetectoristApp.DAL.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DetectoristDbContext _databaseContext;
    public IDetectoristRepository DetectoristRepository { get; }
    public IMetaldetectorRepository MetaldetectorRepository { get; }
    public ICoilRepository CoilRepository { get; }

    public UnitOfWork(DetectoristDbContext databaseContext, IDetectoristRepository detectoristRepository, IMetaldetectorRepository metaldetectorRepository, ICoilRepository coilRepository)
    {
        _databaseContext = databaseContext;
        DetectoristRepository = detectoristRepository;
        MetaldetectorRepository = metaldetectorRepository;
        CoilRepository = coilRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _databaseContext.SaveChangesAsync();
    }
}