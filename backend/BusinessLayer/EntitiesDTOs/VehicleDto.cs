
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.EntitiesDTOs;

public class VehicleDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public int ConditionId { get; set; }
    public int DriveTypeId { get; set; }
    public int FuelTypeId { get; set; }
    public int GearboxTypeId { get; set; }
    public List<IFormFile> Photos { get; set; }
}