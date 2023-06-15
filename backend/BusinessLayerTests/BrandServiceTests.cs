using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using BusinessLayerTests.TestData;
using DataLayer.ContextInterface;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
namespace BusinessLayerTests;

public class BrandServiceTests
{

    private BrandService _brandService;
    private List<Brand> _brands = BrandData.GetBrands();

    [SetUp]
    public void Setup()
    {
        
        
    }

    [Test]
    public void GetAll_ShouldReturnAllBrands()
    {
        var mockContext = new Mock<MockContext>();
        mockContext.Setup(context => context.Brands)
            .ReturnsDbSet(_brands);
        _brandService = new BrandService(mockContext.Object);
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
        var mockContext = new Mock<MockContext>();
        mockContext.Setup(context => context.Brands)
            .ReturnsDbSet(_brands);
        _brandService = new BrandService(mockContext.Object);
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
        var mockContext = new Mock<MockContext>();
        mockContext.Setup(context => context.Brands)
            .ReturnsDbSet(_brands);
        _brandService = new BrandService(mockContext.Object);
        Assert.Throws<KeyNotFoundException>(delegate { _brandService.GetById(5); });
    }

    [Test]
    public void Create_ShouldAddNewBrand()
    {
        var mockBrands = BrandData.GetBrands();
        var mockContext = new Mock<MockContext>();
        mockContext.Setup(context => context.Brands)
            .ReturnsDbSet(mockBrands);
        _brandService = new BrandService(mockContext.Object);
        var newBrand = new Brand { ID = 4, Name = "Kia" };
        _brandService.Create(newBrand);
        var result = _brandService.GetById(newBrand.ID);
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo(newBrand.Name));
    }
}