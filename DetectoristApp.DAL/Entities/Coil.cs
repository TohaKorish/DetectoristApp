using System.ComponentModel.DataAnnotations;

namespace DetectoristApp.DAL.Entities;

public class Coil
{
    [Key]
    public int Id { get; set; }

    public string Brand { get; set; }
    
    public string Model { get; set; }
    
    public double Diameter { get; set; }

    public List<Metaldetector> Metaldetectors { get; set; }
}