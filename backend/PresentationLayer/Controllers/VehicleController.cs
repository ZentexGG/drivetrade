using BusinessLayer.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

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
        try
        {
            var vehicle = _service.GetById(id);
            return Ok(vehicle);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateVehicle(Vehicle vehicle)
    {
        try
        {
            _service.Create(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.ID }, vehicle);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}