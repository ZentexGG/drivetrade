using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services;

public class BrandService : IBrandService
{
    private readonly DriveTradeContext _context;
    public BrandService(DriveTradeContext context)
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
            _context.Add(brand);
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
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}