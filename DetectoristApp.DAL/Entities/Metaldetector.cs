using System.ComponentModel.DataAnnotations;

namespace DetectoristApp.DAL.Entities;

public class Metaldetector
{
    [Key]
    public int Id { get; set; }

    public string Brand { get; set; }
    
    public string Model { get; set; }
    
    public double Weight { get; set; }
    
    public bool IsWaterproof { get; set; }
    
    public List<Detectorist> Detectorists { get; set; }
    
    public int CoilId { get; set; }
    public Coil Coil { get; set; }
}