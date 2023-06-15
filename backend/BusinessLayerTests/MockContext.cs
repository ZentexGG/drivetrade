using DataLayer.ContextInterface;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using DriveType = DataLayer.Entities.DriveType;

namespace BusinessLayerTests;

public class MockContext : DbContext, IDbContext
{
    public virtual DbSet<Brand> Brands { get; set; } = null!;
    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Condition> Conditions { get; set; } = null!;
    public virtual DbSet<DriveType> DriveTypes { get; set; } = null!;
    public virtual DbSet<FuelType> FuelTypes { get; set; } = null!;
    public virtual DbSet<GearboxType> GearboxTypes { get; set; } = null!;
    public virtual DbSet<VehiclePhoto> VehiclePhotos { get; set; } = null!;
    public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

    public void UpdateEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class
    { 
        Entry(entity).State = state;
    }
}