using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

public class VehiclePhoto
{
    [Key] 
    public int ID { get; set; }

    public byte[] ImageData { get; set; }
    public string FileName { get; set; }
    public DateTime UploadDate { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
}