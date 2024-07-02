using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskListApi.Controllers.TasksController;
using TaskListApi.Interface.ITaskRepository;
using TaskListApi.Models.TaskItem;

namespace TaskListApi.Tests.TasksControllerTests
{
    public class TasksControllerTests
    {
        private readonly Mock<ITaskRepository> _mockRepo;
        private readonly TasksController _controller;

        public TasksControllerTests()
        {
            _mockRepo = new Mock<ITaskRepository>();
            _controller = new TasksController(_mockRepo.Object);
        }

        [Fact]
        public async Task Get_Returns_AllTasks()
        {
            // Arrange
            var tasks = new List<TaskItem> { new TaskItem { Id = "1", Title = "Test Task" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tasks);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task Get_Returns_TaskById()
        {
            // Arrange
            var task = new TaskItem { Id = "1", Title = "Test Task" };
            _mockRepo.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(task);

            // Act
            var result = await _controller.Get("1");

            // Assert
            Assert.Equal(task, result.Value);
        }

        [Fact]
        public async Task Post_Creates_Task()
        {
            // Arrange
            var task = new TaskItem { Id = "1", Title = "Test Task" };

            // Act
            var result = await _controller.Post(task);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(task, createdAtActionResult.Value);
        }

        [Fact]
        public async Task Put_Updates_Task()
        {
            // Arrange
            var task = new TaskItem { Id = "1", Title = "Test Task" };
            _mockRepo.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(task);

            // Act
            var result = await _controller.Put("1", task);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_Deletes_Task()
        {
            // Arrange
            var task = new TaskItem { Id = "1", Title = "Test Task" };
            _mockRepo.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(task);

            // Act
            var result = await _controller.Delete("1");

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
