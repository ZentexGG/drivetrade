using BusinessLayer.Interfaces;
using DataLayer.ContextInterface;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services;

public class CategoryService : ICategoryService
{
    private readonly IDbContext _context;

    public CategoryService(IDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories;
    }

    public Category GetById(int id)
    {
        var category = _context.Categories.FirstOrDefault(b => b.ID == id);
        if (category == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }

        return category;
    }

    public void Create(Category category)
    {
        try
        {
            _context.Categories.Add(category);
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

    public void Update(int id, Category category)
    {
        var categoryToUpdate = _context.Categories.FirstOrDefault(b => b.ID == id);
        if (categoryToUpdate == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }
        var properties = typeof(Category).GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(category);
            property.SetValue(categoryToUpdate, value);
        }

        _context.UpdateEntityState(categoryToUpdate, EntityState.Modified);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var categoryToDelete = _context.Categories.FirstOrDefault(b => b.ID == id);
        if (categoryToDelete == null)
        {
            throw new KeyNotFoundException("The specified id was not found!");
        }

        _context.Categories.Remove(categoryToDelete);
        _context.SaveChanges();
    }
}