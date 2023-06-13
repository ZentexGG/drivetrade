using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IVehicleService
{
    IEnumerable<Vehicle> GetAll();
    Vehicle GetById(int id);
    void Create(Vehicle vehicle);
    void Update(int id, Vehicle vehicle);
    void Delete(int id);
}