using AutoMapper;
using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;
using DetectoristApp.BLL.Exceptions;
using DetectoristApp.BLL.Interfaces.Services;
using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Interfaces;
using DetectoristApp.DAL.Interfaces.Repositories;

namespace DetectoristApp.BLL.Services;

public class CoilService : ICoilService
{
    private readonly ICoilRepository _coilRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CoilService(ICoilRepository coilRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _coilRepository = coilRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<CoilResponseDTO>> GetAllAsync()
    {
        var coils = await _coilRepository.GetAllAsync();
        
        return _mapper.Map<List<CoilResponseDTO>>(coils);
    }
    
    public async Task<CoilResponseDTO> GetByIdAsync(int id)
    {
        var coil = await _coilRepository.GetByIdAsync(id);
        
        if (coil == null) throw new EntityNotFoundException($"Coil with id {id} was not found");
        
        return _mapper.Map<CoilResponseDTO>(coil);
    }

    public async Task<CoilResponseDTO> SaveAsync(CoilRequestDTO coilRequestDto)
    {
        var coil = _mapper.Map<CoilRequestDTO, Coil>(coilRequestDto);
        var inserted = await _coilRepository.AddAsync(coil);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<Coil, CoilResponseDTO>(inserted);
    }
    
    public async Task UpdateAsync(CoilRequestDTO coilRequestDto, int id)
    {
        var coil = _mapper.Map<CoilRequestDTO, Coil>(coilRequestDto);
        coil.Id = id;
        _coilRepository.UpdateAsync(coil);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var coil = await _coilRepository.GetByIdAsync(id);
        if (coil == null)
        {
            throw new EntityNotFoundException($"Coil with id {id} hasn't deleted because it was not found");
        }
        
        _coilRepository.DeleteAsync(coil);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<List<CoilResponseDTO>> GetByBrandAsync(string brand)
    {
        var coils = await _coilRepository.GetByBrandAsync(brand);
        
        return _mapper.Map<List<CoilResponseDTO>>(coils);
    }
    
    public async Task<CoilResponseDTO> GetByBrandAndModelAsync(string brand, string model)
    {
        var coil = await _coilRepository.GetByBrandAndModelAsync(brand: brand, model: model);
        
        if (coil == null)
        {
            throw new EntityNotFoundException($"Coil with model {model} and brand {brand} hasn't deleted because it was not found");
        }
        return _mapper.Map<CoilResponseDTO>(coil);
    }

}