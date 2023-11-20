namespace DetectoristApp.BLL.DTO.Response;

public class DetectoristResponseDTO
{
    public int Id { get; set; }

    public string Username { get; set; }
    
    public int Age { get; set; }
    
    public string Sex { get; set; }
    
    public int MetaldetectorId { get; set; }
    public MetaldetectorResponseDTO Metaldetector { get; set; }
}