using System.ComponentModel.DataAnnotations;

namespace DetectoristApp.BLL.DTO.Request;

public class DetectoristRequestDTO
{
    public string Username { get; set; }
    
    public int Age { get; set; }
    
    public string Sex { get; set; }
    
    public int MetaldetectorId { get; set; }
}