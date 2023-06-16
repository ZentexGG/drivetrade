using DataLayer.Entities;

namespace BusinessLayerTests.TestData;

public static class BrandData
{
    public static List<Brand> GetBrands()
    {
        return new List<Brand>
        {
            new() { ID = 1, Name = "Toyota" },
            new() { ID = 2, Name = "Volkswagen" },
            new() { ID = 3, Name = "BMW" }
        };
    }
}