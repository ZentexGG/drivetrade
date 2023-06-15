using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IFuelTypeService
{
    IEnumerable<FuelType> GetAll();
    FuelType GetById(int id);
    void Create(FuelType fuelType);
    void Update(int id, FuelType fuelType);
    void Delete(int id);
}