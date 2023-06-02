using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using DriveType = DataLayer.Entities.DriveType;

namespace DataLayer.Data;

// Commands for creating migrations and updating DB

// dotnet ef migrations add MIGRATION_NAME --startup-project PresentationLayer --project DataLayer --context DriveTradeContext
// dotnet ef database update --startup-project PresentationLayer --project DataLayer

public class DriveTradeContext : DbContext
{

    public DriveTradeContext(DbContextOptions<DriveTradeContext> options) : base(options) { }
    
    
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Condition> Conditions { get; set; } = null!;
    public DbSet<DriveType> DriveTypes { get; set; } = null!;
    public DbSet<FuelType> FuelTypes { get; set; } = null!;
    public DbSet<GearboxType> GearboxTypes { get; set; } = null!;
    public DbSet<VehiclePhoto> VehiclePhotos { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
}