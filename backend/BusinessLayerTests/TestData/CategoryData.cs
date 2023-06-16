using DataLayer.Entities;

namespace BusinessLayerTests.TestData;

public static class CategoryData
{
    public static List<Category> GetCategories()
    {
        return new List<Category>
        {
            new Category { ID = 1, Name = "Cars" },
            new Category { ID = 2, Name = "Motorcycles" },
            new Category { ID = 3, Name = "Scooters" }
        };
    }
}