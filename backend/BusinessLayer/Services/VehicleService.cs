using BusinessLayer.EntitiesDTOs;
using BusinessLayer.Interfaces;
using DataLayer.ContextInterface;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services;

public class VehicleService : IVehicleService
{
    private readonly IDbContext _context;
    public VehicleService(IDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Vehicle> GetAll()
    {
        var vehicles = _context.Vehicles
            .Include(v => v.Brand)
            .Include(v => v.DriveType)
            .Include(v => v.Category)
            .Include(v => v.Condition)
            .Include(v => v.FuelType)
            .Include(v => v.GearboxType);
        return vehicles;
    }

    public Vehicle GetById(int id)
    {
        var vehicle = _context.Vehicles
            .Include(v => v.Brand)
            .Include(v => v.DriveType)
            .Include(v => v.Category)
            .Include(v => v.Condition)
            .Include(v => v.FuelType)
            .Include(v => v.GearboxType)
            .Include(v => v.Photos)
            .AsNoTracking()
            .FirstOrDefault(v => v.ID == id);
        if (vehicle == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }
        return vehicle;
    }

    public async Task<Vehicle> Create(VehicleDto vehicle)
    {
        try { 
            var newVehicle = new Vehicle
            {
                Name = vehicle.Name,
                Price = vehicle.Price,
                Description = vehicle.Description,
                CategoryId = vehicle.CategoryId,
                BrandId = vehicle.BrandId,
                ConditionId = vehicle.ConditionId,
                DriveTypeId = vehicle.DriveTypeId,
                FuelTypeId = vehicle.FuelTypeId,
                GearboxTypeId = vehicle.GearboxTypeId
            };
            _context.Vehicles.Add(newVehicle);
            await _context.SaveChangesAsync();
            if (!vehicle.Photos.Any())
            {
                return newVehicle;
            }
            
            foreach (var vehiclePhoto in vehicle.Photos)
            {
                using var stream = new MemoryStream();
                await vehiclePhoto.CopyToAsync(stream);

                var photo = new VehiclePhoto
                {
                    FileName = vehiclePhoto.FileName,
                    ImageData = stream.ToArray(),
                    UploadDate = DateTime.UtcNow,
                    VehicleId = newVehicle.ID
                };
                _context.VehiclePhotos.Add(photo);
            }

            await _context.SaveChangesAsync();

            return newVehicle;
        }

        catch (DbUpdateException e)
        {
            throw new ApplicationException("Failed to post due to a database error.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("Failed to post!", e);
        }
        
    }

    public void Update(int id, Vehicle vehicle)
    {
        var vehicleToUpdate = _context.Vehicles.FirstOrDefault(v => v.ID == id);
        if (vehicleToUpdate == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }
        var properties = typeof(Vehicle).GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(vehicle);
            property.SetValue(vehicleToUpdate, value);
        }

        _context.Vehicles.Entry(vehicleToUpdate).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var vehicleToDelete = _context.Vehicles.FirstOrDefault(v => v.ID == id);
        if (vehicleToDelete == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }

        _context.Vehicles.Remove(vehicleToDelete);
        _context.SaveChanges();
    }
}