using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;

namespace DetectoristApp.BLL.Interfaces.Services;

public interface ICoilService
{
    Task<List<CoilResponseDTO>> GetAllAsync();
    Task<CoilResponseDTO> GetByIdAsync(int id);
    Task<CoilResponseDTO> SaveAsync(CoilRequestDTO coilRequestDto);
    Task UpdateAsync(CoilRequestDTO coilRequestDto, int id);
    Task DeleteAsync(int id);
    Task<List<CoilResponseDTO>> GetByBrandAsync(string brand);
    Task<CoilResponseDTO> GetByBrandAndModelAsync(string brand, string model);
}