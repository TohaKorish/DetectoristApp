using AutoMapper;
using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;
using DetectoristApp.DAL.Entities;

namespace DetectoristApp.BLL.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<DetectoristRequestDTO, Detectorist>();
        CreateMap<MetaldetectorRequestDTO, Metaldetector>();
        CreateMap<CoilRequestDTO, Coil>();

        CreateMap<Detectorist, DetectoristResponseDTO>().MaxDepth(1);
        CreateMap<Metaldetector, MetaldetectorResponseDTO>().MaxDepth(1);
        CreateMap<Coil, CoilResponseDTO>().MaxDepth(1);
    }
}