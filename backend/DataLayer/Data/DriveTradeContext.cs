using DataLayer.ContextInterface;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using DriveType = DataLayer.Entities.DriveType;

namespace DataLayer.Data;

// Commands for creating migrations and updating DB

// dotnet ef migrations add MIGRATION_NAME --startup-project PresentationLayer --project DataLayer --context DriveTradeContext
// dotnet ef database update --startup-project PresentationLayer --project DataLayer

public class DriveTradeContext : DbContext, IDbContext
{
    public DriveTradeContext() : base() {}
    public DriveTradeContext(DbContextOptions<DriveTradeContext> options) : base(options) { }
    
    public void UpdateEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class
    {
        Entry(entity).State = state;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the relationships

        // Vehicle - Category
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Category)
            .WithMany()
            .IsRequired();

        // Vehicle - Brand
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Brand)
            .WithMany()
            .IsRequired();

        // Vehicle - VehiclePhoto
        modelBuilder.Entity<Vehicle>()
            .HasMany(v => v.Photos)
            .WithOne(p => p.Vehicle)
            .HasForeignKey(p => p.VehicleId)
            .IsRequired();

        // VehiclePhoto - Vehicle
        modelBuilder.Entity<VehiclePhoto>()
            .HasOne(p => p.Vehicle)
            .WithMany(v => v.Photos)
            .HasForeignKey(p => p.VehicleId)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);
    }

    
    
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Condition> Conditions { get; set; } = null!;
    public DbSet<DriveType> DriveTypes { get; set; } = null!;
    public DbSet<FuelType> FuelTypes { get; set; } = null!;
    public DbSet<GearboxType> GearboxTypes { get; set; } = null!;
    public DbSet<VehiclePhoto> VehiclePhotos { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
}