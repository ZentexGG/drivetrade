using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessLayer.EntitiesDTOs;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using VehicleDto = BusinessLayer.EntitiesDTOs.VehicleDto;

namespace PresentationLayer.Controllers;
[ApiController]
[Route("api/vehicle")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _service;

    public VehicleController(IVehicleService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllVehicles()
    {
        var vehicles = _service.GetAll();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public IActionResult GetVehicleById(int id)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        try
        {
            var vehicle = _service.GetById(id);
            var photoDtos = vehicle.Photos?.Select(VehiclePhotoDTO.FromEntity).ToList();
            var responseDto = new
            {
                vehicle.ID,
                vehicle.Name,
                vehicle.YearManufactured,
                vehicle.Mileage,
                vehicle.Description,
                vehicle.Price,
                vehicle.IsNegotiable,
                vehicle.PostedTime,
                vehicle.CategoryId,
                vehicle.Category,
                vehicle.BrandId,
                vehicle.Brand,
                vehicle.ConditionId,
                vehicle.Condition,
                vehicle.DriveTypeId,
                vehicle.DriveType,
                vehicle.FuelTypeId,
                vehicle.FuelType,
                vehicle.GearboxTypeId,
                vehicle.GearboxType,
                Photos = photoDtos
            };
            var res = JsonSerializer.Serialize(responseDto, jsonOptions);
            return Ok(res);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromForm] VehicleDto vehicle)
    {
        try
        {
            var createdVehicle = await _service.Create(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = createdVehicle.ID }, vehicle);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateVehicle(int id, Vehicle newVehicle)
    {
        try
        {
            _service.Update(id, newVehicle);
            return Ok($"Successfully updated vehicle with ID {id}");
        }
        catch (KeyNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteVehicle(int id)
    {
        try
        {
            _service.Delete(id);
            return Ok($"Successfully deleted vehicle with ID {id}");
        }
        catch (KeyNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
}