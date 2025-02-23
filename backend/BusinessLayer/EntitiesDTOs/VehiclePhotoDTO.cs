using DataLayer.Entities;

namespace BusinessLayer.EntitiesDTOs;

public class VehiclePhotoDTO
{
    public int ID { get; set; }
    public string ImageUrl { get; set; }
    public DateTime UploadDate { get; set; }
    public int VehicleId { get; set; }

    public static VehiclePhotoDTO FromEntity(VehiclePhoto photo)
    {
        return new VehiclePhotoDTO
        {
            ID = photo.ID,
            ImageUrl = photo.ImageUrl,
            UploadDate = photo.UploadDate,
            VehicleId = photo.VehicleId
        };
    }

    public static VehiclePhoto ToEntity(VehiclePhotoDTO photo)
    {
        return new VehiclePhoto
        {
            ID = photo.ID,
            ImageUrl = photo.ImageUrl,
            UploadDate = photo.UploadDate,
            VehicleId = photo.VehicleId
        };
    }
}