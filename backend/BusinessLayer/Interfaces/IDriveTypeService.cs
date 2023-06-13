using DataLayer.Entities;
using DriveType = DataLayer.Entities.DriveType;

namespace BusinessLayer.Interfaces;

public interface IDriveTypeService
{
    IEnumerable<DriveType> GetAll();
    DriveType GetById(int id);
    void Create(DriveType driveType);
    void Update(int id, DriveType driveType);
    void Delete(int id);
}