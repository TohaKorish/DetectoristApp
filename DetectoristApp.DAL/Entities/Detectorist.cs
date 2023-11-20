using System.ComponentModel.DataAnnotations;

namespace DetectoristApp.DAL.Entities;

public class Detectorist
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; }
    
    [Range(16, 99)]
    public int Age { get; set; }
    
    public string Sex { get; set; }
    
    public int MetaldetectorId { get; set; }
    public Metaldetector Metaldetector { get; set; }
}