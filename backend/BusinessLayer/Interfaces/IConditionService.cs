using DataLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IConditionService
{
    IEnumerable<Condition> GetAll();
    Condition GetById(int id);
    void Create(Condition condition);
    void Update(int id, Condition condition);
    void Delete(int id);
}