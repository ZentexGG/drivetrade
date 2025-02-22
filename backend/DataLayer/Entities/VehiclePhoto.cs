using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

public class VehiclePhoto
{
    [Key] 
    public int ID { get; set; }
    public string ImageUrl { get; set; }
    public DateTime UploadDate { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
}