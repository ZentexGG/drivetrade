using BusinessLayer.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/brand")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _service;

    public BrandController(IBrandService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllBrands()
    {
        var vehicles = _service.GetAll();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public IActionResult GetBrandById(int id)
    {
        try
        {
            var brand = _service.GetById(id);
            return Ok(brand);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateBrand(Brand brand)
    {
        try
        {
            _service.Create(brand);
            return CreatedAtAction(nameof(GetBrandById), new { id = brand.ID }, brand);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBrand(int id, Brand newBrand)
    {
        try
        {
            _service.Update(id, newBrand);
            return Ok(new { message = $"Successfully updated brand with ID {id}" });
        }
        catch (KeyNotFoundException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBrand(int id)
    {
        try
        {
            _service.Delete(id);
            return Ok($"Successfully deleted brand with ID {id}");
        }
        catch (KeyNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
}