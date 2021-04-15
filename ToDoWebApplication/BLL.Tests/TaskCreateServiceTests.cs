using System;
using System.Threading.Tasks;
using AutoFixture;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.BLL.Contracts;
using ToDoWebApplication.BLL.Implementations;
using ToDoWebApplication.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ToDoWebApplication.BLL.Tests
{
    public class EmployeeCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_DepartmentValidationSucceed_CreatesTask()
        {
            // Arrange
            var task = new TaskUpdateModel();
            var expected = new Domain.Task();

            var categoryGetService = new Mock<ICategoryGetService>();
            categoryGetService.Setup(x => x.ValidateAsync(task));

            var taskDataAccess = new Mock<ITaskDataAccess>();
            taskDataAccess.Setup(x => x.InsertAsync(task)).ReturnsAsync(expected);

            var taskGetService = new TaskCreateService(taskDataAccess.Object, categoryGetService.Object);

            // Act
            var result = await taskGetService.CreateAsync(task);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_DepartmentValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var task = new TaskUpdateModel();
            var expected = fixture.Create<string>();

            var categoryGetService = new Mock<ICategoryGetService>();
            categoryGetService
                .Setup(x => x.ValidateAsync(task))
                .Throws(new InvalidOperationException(expected));

            var taskDataAccess = new Mock<ITaskDataAccess>();

            var taskGetService = new TaskCreateService(taskDataAccess.Object, categoryGetService.Object);

            // Act
            var action = new Func<Task>(() => taskGetService.CreateAsync(task));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            taskDataAccess.Verify(x => x.InsertAsync(task), Times.Never);
        }
    }
}
