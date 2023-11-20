using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;

namespace DetectoristApp.BLL.Interfaces.Services;

public interface IDetectoristService
{
    Task<List<DetectoristResponseDTO>> GetAllAsync();
    Task<DetectoristResponseDTO> GetByIdAsync(int id);
    Task<DetectoristResponseDTO> SaveAsync(DetectoristRequestDTO coilRequestDto);
    Task UpdateAsync(DetectoristRequestDTO coilRequestDto, int id);
    Task DeleteAsync(int id);
    Task<DetectoristResponseDTO> GetByUsernameAsync(string username);
    Task<List<DetectoristResponseDTO>> GetBySexAsync(string sex);
    Task<List<DetectoristResponseDTO>> GetWithWaterproofMetaldetectorAsync();
    Task<List<DetectoristResponseDTO>> GetByMetaldetectorAsync(int id);
    Task<List<DetectoristResponseDTO>> GetByCoilAsync(int id);
}