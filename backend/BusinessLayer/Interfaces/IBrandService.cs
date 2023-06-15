using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IBrandService
{
    IEnumerable<Brand> GetAll();
    Brand GetById(int id);
    void Create(Brand brand);
    void Update(int id, Brand brand);
    void Delete(int id);
}