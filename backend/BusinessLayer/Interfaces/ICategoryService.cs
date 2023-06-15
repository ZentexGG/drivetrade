using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface ICategoryService
{
    IEnumerable<Category> GetAll();
    Category GetById(int id);
    void Create(Category category);
    void Update(int id, Category category);
    void Delete(int id);
}