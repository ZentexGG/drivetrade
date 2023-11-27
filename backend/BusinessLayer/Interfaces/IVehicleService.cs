using BusinessLayer.EntitiesDTOs;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IVehicleService
{
    IEnumerable<Vehicle> GetAll();
    Vehicle GetById(int id);
    Task<Vehicle> Create(VehicleDto vehicle);
    void Update(int id, Vehicle vehicle);
    void Delete(int id);
}