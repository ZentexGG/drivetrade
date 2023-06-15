using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IGearboxTypeService
{
    IEnumerable<GearboxType> GetAll();
    GearboxType GetById(int id);
    void Create(GearboxType gearboxType);
    void Update(int id, GearboxType gearboxType);
    void Delete(int id);
}