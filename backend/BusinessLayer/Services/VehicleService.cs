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
        return _context.Vehicles;
    }

    public Vehicle GetById(int id)
    {
        var vehicle = _context.Vehicles.FirstOrDefault(v => v.ID == id);
        if (vehicle == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }

        return vehicle;
    }

    public void Create(Vehicle vehicle)
    {
        try
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
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