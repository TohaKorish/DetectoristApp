using AutoMapper;
using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;
using DetectoristApp.BLL.Exceptions;
using DetectoristApp.BLL.Interfaces.Services;
using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Interfaces;
using DetectoristApp.DAL.Interfaces.Repositories;

namespace DetectoristApp.BLL.Services;

public class MetaldetectorService : IMetaldetectorService
{
    private readonly IMetaldetectorRepository _metaldetectorRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public MetaldetectorService(IMetaldetectorRepository metaldetectorRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _metaldetectorRepository = metaldetectorRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<MetaldetectorResponseDTO>> GetAllAsync()
    {
        var metaldetectors = await _metaldetectorRepository.GetAllAsync();
        
        return _mapper.Map<List<MetaldetectorResponseDTO>>(metaldetectors);
    }
    
    public async Task<MetaldetectorResponseDTO> GetByIdAsync(int id)
    {
        var metaldetector = await _metaldetectorRepository.GetByIdAsync(id);
        
        if (metaldetector == null) throw new EntityNotFoundException($"Metaldetector with id {id} was not found");
        
        return _mapper.Map<MetaldetectorResponseDTO>(metaldetector);
    }
    
    public async Task<MetaldetectorResponseDTO> SaveAsync(MetaldetectorRequestDTO metaldetectorRequestDto)
    {
        var metaldetector = _mapper.Map<MetaldetectorRequestDTO, Metaldetector>(metaldetectorRequestDto);
        var inserted = await _metaldetectorRepository.AddAsync(metaldetector);

        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Metaldetector, MetaldetectorResponseDTO>(inserted);
    }
    
    public async Task UpdateAsync(MetaldetectorRequestDTO metaldetectorRequestDto, int id)
    {
        var metaldetector = _mapper.Map<MetaldetectorRequestDTO, Metaldetector>(metaldetectorRequestDto);

        metaldetector.Id = id;
        _metaldetectorRepository.UpdateAsync(metaldetector);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var metaldetector = await _metaldetectorRepository.GetByIdAsync(id);
        if (metaldetector == null)
        {
            throw new EntityNotFoundException($"Metaldetector with id {id} hasn't deleted because it was not found");
        }
        
        _metaldetectorRepository.DeleteAsync(metaldetector);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<List<MetaldetectorResponseDTO>> GetByBrandAsync(string brand)
    {
        var metaldetectors = await _metaldetectorRepository.GetByBrandAsync(brand);
        
        return _mapper.Map<List<MetaldetectorResponseDTO>>(metaldetectors);
    }
    
    public async Task<MetaldetectorResponseDTO> GetByBrandAndModelAsync(string brand, string model)
    {
        var metaldetector = await _metaldetectorRepository.GetByBrandAndModelAsync(brand: brand, model: model);
        
        return _mapper.Map<MetaldetectorResponseDTO>(metaldetector);
    }
}