using System;
using System.Threading.Tasks;
using AutoFixture;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.BLL.Implementations;
using ToDoWebApplication.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Category = ToDoWebApplication.Domain.Category;

namespace ToDoWebApplication.BLL.Tests
{
    [TestFixture]
    public class CategoryGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_CategoryExists_DoesNothing()
        {
            // Arrange
            var category = new Category();
            var categoryContainer = new Mock<ICategoryContainer>();
            var categoryIdentity = new Mock<ICategoryIdentity>();
            var categoryDataAccess = new Mock<ICategoryDataAccess>();
            categoryDataAccess.Setup(x => x.GetAsync(categoryIdentity.Object)).ReturnsAsync(category);
            var categoryGetService = new CategoryGetService(categoryDataAccess.Object);

            // Act
            var action = new Func<Task>(() => categoryGetService.ValidateAsync(categoryContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_CategoryNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            var categoryIdentity = new Mock<ICategoryIdentity>();
            var categoryContainer = new Mock<ICategoryContainer>();
            categoryContainer.Setup(x => x.CategoryId).Returns(id);

            var category = new Category();
            var categoryDataAccess = new Mock<ICategoryDataAccess>();
            categoryDataAccess.Setup(x => x.GetAsync(categoryIdentity.Object)).ReturnsAsync((Category)null);

            var categoryGetService = new CategoryGetService(categoryDataAccess.Object);

            // Act
            var action = new Func<Task>(() => categoryGetService.ValidateAsync(categoryContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Category not found by id {id}");
        }

        [Test]
        public async Task GetAsync_ReturnsCategory()
        {
            // Arrange
            var fixture = new Fixture();
            var categoryIdentity = new Mock<ICategoryIdentity>();
            var id = fixture.Create<int>();
            categoryIdentity.Setup(x => x.Id).Returns(id);
            var expected = new Category() { Id = id };
            var categoryDataAccess = new Mock<ICategoryDataAccess>();
            categoryDataAccess.Setup(x => x.GetAsync(categoryIdentity.Object)).ReturnsAsync(expected);
            var categoryGetService = new CategoryGetService(categoryDataAccess.Object);

            // Act
            var result = await categoryGetService.GetAsync(categoryIdentity.Object);

            // Assert
            result.Should().Be(expected);
        }
    }
}
