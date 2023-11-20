using DetectoristApp.DAL.Interfaces.Repositories;

namespace DetectoristApp.DAL.Interfaces;

public interface IUnitOfWork
{
    public IDetectoristRepository DetectoristRepository { get; }
    public IMetaldetectorRepository MetaldetectorRepository { get; }
    public ICoilRepository CoilRepository { get; }
    public Task SaveChangesAsync();

}