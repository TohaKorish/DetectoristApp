namespace DetectoristApp.BLL.DTO.Request;

public class MetaldetectorRequestDTO
{
    public string Brand { get; set; }
    
    public string Model { get; set; }
    
    public double Weight { get; set; }
    
    public bool IsWaterproof { get; set; }
    
    public int CoilId { get; set; }
}