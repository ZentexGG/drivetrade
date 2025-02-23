using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.EntitiesDTOs;

public class VehiclePhotoUploadDto
{
    public IFormFile File { get; set; }
    public int VehicleId { get; set; }
}
