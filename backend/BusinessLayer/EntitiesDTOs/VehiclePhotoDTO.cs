using DataLayer.Entities;

namespace BusinessLayer.EntitiesDTOs;

public class VehiclePhotoDTO
{
    public int ID { get; set; }
    public byte[] ImageData { get; set; }
    public string FileName { get; set; }
    public DateTime UploadDate { get; set; }
    public int VehicleId { get; set; }

    public static VehiclePhotoDTO FromEntity(VehiclePhoto photo)
    {
        return new VehiclePhotoDTO
        {
            ID = photo.ID,
            ImageData = photo.ImageData,
            FileName = photo.FileName,
            UploadDate = photo.UploadDate,
            VehicleId = photo.VehicleId
        };
    }
}