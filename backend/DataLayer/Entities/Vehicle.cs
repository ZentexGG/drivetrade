using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities;

public class Vehicle
{
    [Key]
    public int ID { get; set; }
    
    public string Name { get; set; }
    public int YearManufactured { get; set; }
    public int Mileage { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public bool IsNegotiable { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime PostedTime { get; set; } = DateTime.Now;
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    
    public int ConditionId { get; set; }
    public Condition Condition { get; set; }

    public int DriveTypeId { get; set; }
    public DriveType DriveType { get; set; }

    public int FuelTypeId { get; set; }
    public FuelType FuelType { get; set; }

    public int GearboxTypeId { get; set; }
    public GearboxType GearboxType { get; set; }
}