using BusinessLayer.Interfaces;
using DataLayer.ContextInterface;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services;

public class BrandService : IBrandService
{
    private readonly IDbContext _context;

    public BrandService(IDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Brand> GetAll()
    {
        return _context.Brands;
    }

    public Brand GetById(int id)
    {
        var brand = _context.Brands.FirstOrDefault(b => b.ID == id);
        if (brand == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }

        return brand;
    }

    public void Create(Brand brand)
    {
        try
        {
            _context.Brands.Add(brand);
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

    public void Update(int id, Brand brand)
    {
        var brandToUpdate = _context.Brands.FirstOrDefault(b => b.ID == id);
        if (brandToUpdate == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }
        var properties = typeof(Brand).GetProperties();
        foreach (var property in properties)
        {
            if (property.Name == "ID")
            {
                continue;
            }
            var value = property.GetValue(brand);
            property.SetValue(brandToUpdate, value);
        }

        _context.UpdateEntityState(brandToUpdate, EntityState.Modified);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var brandToDelete = _context.Brands.FirstOrDefault(b => b.ID == id);
        if (brandToDelete == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }

        _context.Brands.Remove(brandToDelete);
        _context.SaveChanges();
    }
}