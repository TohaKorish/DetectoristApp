using AutoMapper;
using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;
using DetectoristApp.BLL.Exceptions;
using DetectoristApp.BLL.Interfaces.Services;
using DetectoristApp.DAL.Entities;
using DetectoristApp.DAL.Interfaces;
using DetectoristApp.DAL.Interfaces.Repositories;

namespace DetectoristApp.BLL.Services;

public class DetectoristService : IDetectoristService
{
    private readonly IDetectoristRepository _detectoristRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DetectoristService(IDetectoristRepository detectoristRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _detectoristRepository = detectoristRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<DetectoristResponseDTO>> GetAllAsync()
    {
        var detectorists = await _detectoristRepository.GetAllAsync();
        
        return _mapper.Map<List<DetectoristResponseDTO>>(detectorists);
    }
    
    public async Task<DetectoristResponseDTO> GetByIdAsync(int id)
    {
        var detectorist = await _detectoristRepository.GetByIdAsync(id);
        
        if (detectorist == null) throw new EntityNotFoundException($"Detectorist with id {id} was not found");
        
        return _mapper.Map<DetectoristResponseDTO>(detectorist);
    }
    
    public async Task<DetectoristResponseDTO> SaveAsync(DetectoristRequestDTO detectoristRequestDto)
    {
        if (!IsValidSex(detectoristRequestDto.Sex))
        {
            throw new InvalidSexException("Sex must be 'Male' or 'Female'");
        }
        
        var detectorist = _mapper.Map<DetectoristRequestDTO, Detectorist>(detectoristRequestDto);
        var oldDetectorist = _detectoristRepository.GetByUsernameAsync(detectorist.Username);
        if (oldDetectorist != null)
        {
            throw new UsernameIsTakenException("Username is already taken");
        }

        var inserted = await _detectoristRepository.AddAsync(detectorist);

        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<Detectorist, DetectoristResponseDTO>(inserted);
    }
    
    public async Task UpdateAsync(DetectoristRequestDTO detectoristRequestDto, int id)
    {
        if (!IsValidSex(detectoristRequestDto.Sex))
        {
            throw new InvalidSexException("Sex must be 'Male' or 'Female'");
        }
        
        var detectorist = _mapper.Map<DetectoristRequestDTO, Detectorist>(detectoristRequestDto);
        var oldDetectorist = _detectoristRepository.GetByUsernameAsync(detectorist.Username);
        if (oldDetectorist != null && oldDetectorist.Id != id )
        {
            throw new UsernameIsTakenException("Username is already taken");
        }

        detectorist.Id = id;
        await _detectoristRepository.AddAsync(detectorist);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        var detectorist = await _detectoristRepository.GetByIdAsync(id);
        if (detectorist == null)
        {
            throw new EntityNotFoundException($"Detectorist with id {id} hasn't deleted because it was not found");
        }
        
        _detectoristRepository.DeleteAsync(detectorist);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<DetectoristResponseDTO> GetByUsernameAsync(string username)
    {
        var detectorist = await _detectoristRepository.GetByUsernameAsync(username);

        if (detectorist == null)
        {
            throw new EntityNotFoundException($"Detectorist with username {username} not found");
        }
        
        return _mapper.Map<DetectoristResponseDTO>(detectorist);
    }

    public async Task<List<DetectoristResponseDTO>> GetBySexAsync(string sex)
    {
        sex = sex.First().ToString().ToUpper() + sex.Substring(1);
        var detectorists = await _detectoristRepository.GetDetectoristsBySexAsync(sex);
        
        return _mapper.Map<List<DetectoristResponseDTO>>(detectorists);
    }

    public async Task<List<DetectoristResponseDTO>> GetWithWaterproofMetaldetectorAsync()
    {
        var detectorists = await _detectoristRepository.GetDetectoristsWithWaterproofDetectorAsync();

        return _mapper.Map<List<DetectoristResponseDTO>>(detectorists);
    }
    
    public async Task<List<DetectoristResponseDTO>> GetByMetaldetectorAsync(int id)
    {
        var detectorists = await _detectoristRepository.GetByMetaldetectorAsync(id);

        return _mapper.Map<List<DetectoristResponseDTO>>(detectorists);
    }
    
    public async Task<List<DetectoristResponseDTO>> GetByCoilAsync(int id)
    {
        var detectorists = await _detectoristRepository.GetByCoilAsync(id);

        return _mapper.Map<List<DetectoristResponseDTO>>(detectorists);
    }

    private static bool IsValidSex(string sex)
    {
        return sex.Equals("Male") || sex.Equals("Female");
    }
}