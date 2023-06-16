using BusinessLayer.Services;
using BusinessLayerTests.TestData;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace BusinessLayerTests.Tests
{
    public class CategoryServiceTests
    {
        private Mock<MockContext> _mockContext;
        private CategoryService _categoryService;
        private List<Category> _categories = CategoryData.GetCategories();

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<MockContext>();
            _mockContext.Setup(context => context.Categories)
                .ReturnsDbSet(_categories);
            _mockContext.Setup(context => context.UpdateEntityState(It.IsAny<Category>(), It.IsAny<EntityState>()))
                .Verifiable();
            _categoryService = new CategoryService(_mockContext.Object);
        }

        [Test]
        public void GetAll_ShouldReturnAllCategories()
        {
            var results = _categoryService.GetAll().ToArray();
            Assert.That(results, Is.Not.Null);
            Assert.That(results, Has.Length.EqualTo(_categories.Count));
            for (var i = 0; i < results.Length; i++)
            {
                Assert.That(results[i].Name, Is.EqualTo(_categories[i].Name));
            }
        }

        [Test]
        public void GetByIdUsingCorrectId_ShouldReturnCategory()
        {
            var result = _categoryService.GetById(2);
            var actual = _categories.First(c => c.ID == 2);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Name, Is.EqualTo(actual.Name));
                Assert.That(result.ID, Is.EqualTo(actual.ID));
            });
        }

        [Test]
        public void GetByIdUsingWrongId_ShouldThrowException()
        {
            Assert.Throws<KeyNotFoundException>(delegate { _categoryService.GetById(5); });
        }

        [Test]
        public void Create_ShouldAddNewCategory()
        {
            var newCategory = new Category { ID = 4, Name = "SUV" };

            _categoryService.Create(newCategory);

            _mockContext.Verify(c => c.Categories.Add(It.IsAny<Category>()), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void Update_ShouldUpdateExistingCategory()
        {
            var existingCategory = _categories[0];
            var newCategory = new Category { ID = 1, Name = "Sedan" };
            _categoryService.Update(existingCategory.ID, newCategory);

            _mockContext.Verify(c => c.UpdateEntityState(existingCategory, EntityState.Modified), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void Delete_ShouldRemoveCategory()
        {
            var categoryToRemove = _categories[0];
            _categoryService.Delete(categoryToRemove.ID);
            _mockContext.Verify(c => c.Categories.Remove(categoryToRemove));
            _mockContext.Verify(c => c.SaveChanges());
        }
    }
}
