using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IVehiclePhotoService
{
    IEnumerable<VehiclePhoto> GetAll();
    VehiclePhoto GetById(int id);
    void Create(VehiclePhoto vehiclePhoto);
    void Update(int id, VehiclePhoto vehiclePhoto);
    void Delete(int id);
}