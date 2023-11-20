namespace DetectoristApp.BLL.DTO.Response;

public class CoilResponseDTO
{
    public int Id { get; set; }

    public string Brand { get; set; }
    
    public string Model { get; set; }
    
    public double Diameter { get; set; }

    public List<MetaldetectorResponseDTO> Metaldetectors { get; set; }
}