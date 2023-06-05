using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities;

public class Vehicle
{
    [Key]
    public int ID { get; set; }
    [Required]
    public Category Category { get; set; }
    [Required]
    public Brand Brand { get; set; }
    [Required] 
    public string Name { get; set; }
    [Required] 
    public int YearManufactured { get; set; }
    [Required]
    public int Mileage { get; set; }
    
    
    public string? Description { get; set; }
    [Required] 
    public double Price { get; set; }
    [Required] 
    public bool IsNegotiable { get; set; }
    [Required]
    public DateTime PostedTime { get; set; }

    public List<VehiclePhoto> Photos { get; set; }
}