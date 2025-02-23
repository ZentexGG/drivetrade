using BusinessLayer.EntitiesDTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace PresentationLayer.Controllers
{
    [Route("api/vehiclephoto")]
    [ApiController]
    public class VehiclePhotoController(IVehiclePhotoService service) : ControllerBase
    {
        private readonly IVehiclePhotoService _service = service;
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromForm] VehiclePhotoUploadDto vehiclePhotoUploadDto)
        {
            try
            {
                var createdVehicle = await _service.Create(vehiclePhotoUploadDto);
                return Ok(JsonSerializer.Serialize(createdVehicle));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
