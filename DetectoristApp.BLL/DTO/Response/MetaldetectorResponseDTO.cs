namespace DetectoristApp.BLL.DTO.Response;

public class MetaldetectorResponseDTO
{
    public int Id { get; set; }

    public string Brand { get; set; }
    
    public string Model { get; set; }
    
    public double Weight { get; set; }
    
    public bool IsWaterproof { get; set; }
    
    public List<DetectoristResponseDTO> Detectorists { get; set; }
    
    public int CoilId { get; set; }
    public CoilResponseDTO Coil { get; set; }
}