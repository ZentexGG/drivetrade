
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.EntitiesDTOs;

public class VehicleDto
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public bool IsNegotiable { get; set; }
    public bool IsAvailable { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }
    public int CategoryId { get; set; }
    public string Brand { get; set; }
    public int BrandId { get; set; }
    public string Condition { get; set; }
    public int ConditionId { get; set; }
    public int DriveTypeId { get; set; }
    public string DriveType { get; set; }
    public string? DriveTypeAbbr { get; set; }
    public int FuelTypeId { get; set; }
    public string FuelType { get; set; }
    public string GearboxType { get; set; }
    public int GearboxTypeId { get; set; }
    public List<IFormFile> Photos { get; set; }

    public static VehicleDto FromEntity(Vehicle vehicle)
    {
        return new VehicleDto
        {
            ID = vehicle.ID,
            Name = vehicle.Name,
            Price = vehicle.Price,
            IsNegotiable = vehicle.IsNegotiable,
            IsAvailable = vehicle.IsAvailable,
            Description = vehicle.Description,
            Category = vehicle.Category.Name,
            CategoryId = vehicle.Category.ID,
            Brand = vehicle.Brand.Name,
            BrandId = vehicle.Brand.ID,
            Condition = vehicle.Condition.Name,
            ConditionId = vehicle.Condition.ID,
            DriveTypeId = vehicle.DriveType.ID,
            DriveType = vehicle.DriveType.Name,
            DriveTypeAbbr = vehicle.DriveType.Abbreviation,
            FuelType = vehicle.FuelType.Name,
            FuelTypeId = vehicle.FuelType.ID,
            GearboxType = vehicle.GearboxType.Name,
            GearboxTypeId = vehicle.GearboxType.ID
        };
    }
}

