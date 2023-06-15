using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using DriveType = DataLayer.Entities.DriveType;

namespace DataLayer.ContextInterface;

public interface IDbContext
{
    DbSet<Brand> Brands { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Condition> Conditions { get; set; }
    DbSet<DriveType> DriveTypes { get; set; }
    DbSet<FuelType> FuelTypes { get; set; }
    DbSet<GearboxType> GearboxTypes { get; set; }
    DbSet<VehiclePhoto> VehiclePhotos { get; set; }
    DbSet<Vehicle> Vehicles { get; set; }

    int SaveChanges();
    void UpdateEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class;
}