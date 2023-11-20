using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;

namespace DetectoristApp.BLL.Interfaces.Services;

public interface IMetaldetectorService
{
    Task<List<MetaldetectorResponseDTO>> GetAllAsync();
    Task<MetaldetectorResponseDTO> GetByIdAsync(int id);
    Task<MetaldetectorResponseDTO> SaveAsync(MetaldetectorRequestDTO coilRequestDto);
    Task UpdateAsync(MetaldetectorRequestDTO coilRequestDto, int id);
    Task DeleteAsync(int id);
    Task<List<MetaldetectorResponseDTO>> GetByBrandAsync(string brand);
    Task<MetaldetectorResponseDTO> GetByBrandAndModelAsync(string brand, string model);
}