using BusinessLayer.Services;
using BusinessLayerTests.TestData;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace BusinessLayerTests.Tests;

public class BrandServiceTests
{
    private Mock<MockContext> _mockContext;
    private BrandService _brandService;
    private List<Brand> _brands = BrandData.GetBrands();

    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<MockContext>();
        _mockContext.Setup(context => context.Brands)
            .ReturnsDbSet(_brands);
        _mockContext.Setup(context => context.UpdateEntityState(It.IsAny<Brand>(), It.IsAny<EntityState>()))
            .Verifiable();
        _brandService = new BrandService(_mockContext.Object);

    }

    [Test]
    public void GetAll_ShouldReturnAllBrands()
    {
        var results = _brandService.GetAll().ToArray();
        Assert.That(results, Is.Not.Null);
        Assert.That(results, Has.Length.EqualTo(_brands.Count));
        for (var i = 0; i < results.Length; i++)
        {
            Assert.That(results[i].Name, Is.EqualTo(_brands[i].Name));
        }
    }

    [Test]
    public void GetByIdUsingCorrectId_ShouldReturnBrand()
    {
        var result = _brandService.GetById(2);
        var actual = _brands.First(b => b.ID == 2);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(actual.Name));
            Assert.That(result.ID, Is.EqualTo(actual.ID));
        });
    }

    [Test]
    public void GetByIdUsingWrongId_ShoulThrowException()
    {
        Assert.Throws<KeyNotFoundException>(delegate { _brandService.GetById(5); });
    }

    [Test]
    public void Create_ShouldAddNewBrand()
    {
        var newBrand = new Brand { ID = 4, Name = "Kia" };

        _brandService.Create(newBrand);
        
        _mockContext.Verify(c => c.Brands.Add(It.IsAny<Brand>()), Times.Once);
        _mockContext.Verify(c => c.SaveChanges(), Times.Once);

    }

    [Test]
    public void Update_ShouldUpdateExistingBrand()
    {
        
        var existingBrand = _brands[0];
        var newBrand = new Brand { ID = 1, Name = "Lexus" };
        _brandService.Update(existingBrand.ID, newBrand);
        
        _mockContext.Verify(c => c.UpdateEntityState(existingBrand, EntityState.Modified), Times.Once);
        _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        
    }

    [Test]
    public void Delete_ShouldRemoveBrand()
    {
        var brandToRemove = _brands[0];
        _brandService.Delete(brandToRemove.ID);
        _mockContext.Verify(c => c.Brands.Remove(brandToRemove));
        _mockContext.Verify(c => c.SaveChanges());
    }
}