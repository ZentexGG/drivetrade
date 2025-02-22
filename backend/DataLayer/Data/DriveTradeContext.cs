using DataLayer.ContextInterface;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using DriveType = DataLayer.Entities.DriveType;

namespace DataLayer.Data;

// Commands for creating migrations and updating DB

// dotnet ef migrations add MIGRATION_NAME --startup-project PresentationLayer --project DataLayer --context DriveTradeContext
// dotnet ef database update --startup-project PresentationLayer --project DataLayer

public sealed class DriveTradeContext : DbContext, IDbContext
{
    
    public DriveTradeContext() : base() {}

    public DriveTradeContext(DbContextOptions<DriveTradeContext> options) : base(options) { }
    
    public void UpdateEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class
    {
        Entry(entity).State = state;
    }
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Vehicle -> Category
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Category)
            .WithMany()
            .HasForeignKey(v => v.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Vehicle -> Brand
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Brand)
            .WithMany()
            .HasForeignKey(v => v.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Vehicle -> Condition
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Condition)
            .WithMany()
            .HasForeignKey(v => v.ConditionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Vehicle -> DriveType
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.DriveType)
            .WithMany()
            .HasForeignKey(v => v.DriveTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Vehicle -> FuelType
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.FuelType)
            .WithMany()
            .HasForeignKey(v => v.FuelTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Vehicle -> GearboxType
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.GearboxType)
            .WithMany()
            .HasForeignKey(v => v.GearboxTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // VehiclePhoto -> Vehicle

        modelBuilder.Entity<VehiclePhoto>()
            .HasOne(v => v.Vehicle)
            .WithMany()
            .HasForeignKey(v => v.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

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