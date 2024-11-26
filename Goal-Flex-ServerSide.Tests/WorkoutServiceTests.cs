using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Goal_Flex_ServerSide.DTOs;
using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Services;
using Moq;
using Xunit;

namespace Goal_Flex_ServerSide.Goal_Flex_ServerSide.Tests
{
    public class WorkoutServiceTests
    {
        private readonly Mock<IWorkoutRepository> _mockRepository;
        private readonly WorkoutService _service;

        public WorkoutServiceTests()
        {
            _mockRepository = new Mock<IWorkoutRepository>();
            _service = new WorkoutService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetWorkoutsAsync_ReturnsListOfWorkouts()
        {
            // Arrange
            var workouts = new List<Workout>
            {
                new Workout { Id = 1, Title = "Cardio", Time = "30", Difficulty = "Easy" },
                new Workout { Id = 2, Title = "Strength", Time = "45", Difficulty = "Hard" }
            };
            _mockRepository.Setup(repo => repo.GetWorkoutsAsync()).ReturnsAsync(workouts);

            // Act
            var result = await _service.GetWorkoutsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Cardio", result[0].Title);
        }

        [Fact]
        public async Task GetWorkoutByIdAsync_ReturnsWorkout_WhenWorkoutExists()
        {
            // Arrange
            var workout = new Workout { Id = 1, Title = "Morning Cardio", Time = "30", Difficulty = "Easy" };
            _mockRepository.Setup(repo => repo.GetWorkoutByIdAsync(1)).ReturnsAsync(workout);

            // Act
            var result = await _service.GetWorkoutByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Morning Cardio", result.Title);
        }

        [Fact]
        public async Task GetWorkoutByIdAsync_ReturnsNull_WhenWorkoutDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetWorkoutByIdAsync(It.IsAny<int>())).ReturnsAsync((Workout)null);

            // Act
            var result = await _service.GetWorkoutByIdAsync(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateWorkoutAsync_ThrowsException_WhenCategoryDoesNotExist()
        {
            // Arrange
            var workout = new Workout { Title = "Yoga", Time = "60", Difficulty = "Medium", CategoryId = 999, UserId = 1 };

            // Mock CategoryExistsAsync to return false for the non-existent category
            _mockRepository.Setup(repo => repo.CategoryExistsAsync(999)).ReturnsAsync(false);

            // Mock UserExistsAsync to return true for a valid UserId (1)
            _mockRepository.Setup(repo => repo.UserExistsAsync(1)).ReturnsAsync(true);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _service.CreateWorkoutAsync(workout));

            // Assert that the exception message is about the non-existent category
            Assert.Equal("There are no categories with the following id: 999", exception.Message);
        }

        [Fact]
        public async Task CreateWorkoutAsync_AddsWorkout_WhenValid()
        {
            // Arrange
            var workout = new Workout { Title = "Yoga", Time = "60", Difficulty = "Medium", CategoryId = 1, UserId = 1 };

            // Ensure CategoryExistsAsync and UserExistsAsync return true
            _mockRepository.Setup(repo => repo.CategoryExistsAsync(1)).ReturnsAsync(true); // Mock CategoryExistsAsync
            _mockRepository.Setup(repo => repo.UserExistsAsync(1)).ReturnsAsync(true); // Mock UserExistsAsync

            // Mock CreateWorkoutAsync to return the workout object
            _mockRepository.Setup(repo => repo.CreateWorkoutAsync(It.IsAny<Workout>())).ReturnsAsync(workout); // Mock CreateWorkoutAsync

            // Act
            var result = await _service.CreateWorkoutAsync(workout);

            // Assert
            Assert.NotNull(result); // Ensure result is not null
            Assert.Equal("Yoga", result.Title); // Verify the title of the created workout
            Assert.Equal("60", result.Time); // Verify the time is correctly set
            Assert.Equal("Medium", result.Difficulty); // Verify the difficulty is correctly set
            Assert.Equal(1, result.CategoryId); // Ensure the CategoryId matches
            Assert.Equal(1, result.UserId); // Ensure the UserId matches

            // Verify that the CreateWorkoutAsync method on the repository was called exactly once
            _mockRepository.Verify(repo => repo.CreateWorkoutAsync(It.IsAny<Workout>()), Times.Once);
        }



        [Fact]
        public async Task UpdateWorkoutAsync_ThrowsException_WhenWorkoutDoesNotExist()
        {
            // Arrange
            var workout = new Workout { Id = 1, Title = "Updated Title", Time = "45" };
            _mockRepository.Setup(repo => repo.GetWorkoutByIdAsync(1)).ReturnsAsync((Workout)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _service.UpdateWorkoutAsync(workout, 1));
            Assert.Equal("There is no user with the following id: 0", exception.Message);
        }

        [Fact]
        public async Task UpdateWorkoutAsync_UpdatesWorkout_WhenValid()
        {
            // Arrange
            var existingWorkout = new Workout { Id = 1, Title = "Old Title", Time = "30", Difficulty = "Easy", UserId = 1, CategoryId = 1 };
            var updatedWorkout = new Workout { Id = 1, Title = "New Title", Time = "45", Difficulty = "Medium", UserId = 1, CategoryId = 1 };

            // Mock repository methods
            _mockRepository.Setup(repo => repo.GetWorkoutByIdAsync(1)).ReturnsAsync(existingWorkout);
            _mockRepository.Setup(repo => repo.UserExistsAsync(1)).ReturnsAsync(true); // Ensure UserExistsAsync returns true for UserId 1
            _mockRepository.Setup(repo => repo.CategoryExistsAsync(1)).ReturnsAsync(true); // Ensure CategoryExistsAsync returns true for CategoryId 1
            _mockRepository.Setup(repo => repo.UpdateWorkoutAsync(updatedWorkout, 1)).ReturnsAsync(updatedWorkout);

            // Act
            var result = await _service.UpdateWorkoutAsync(updatedWorkout, 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Title", result.Title);
            Assert.Equal("45", result.Time);
            Assert.Equal("Medium", result.Difficulty);
            _mockRepository.Verify(repo => repo.UpdateWorkoutAsync(updatedWorkout, 1), Times.Once);
        }

        [Fact]

        public async Task DeleteWorkoutAsync_RemovesWorkout_WhenValid()
        {
            // Arrange
            var workout = new Workout { Id = 1, Title = "Workout to Delete" };
            _mockRepository.Setup(repo => repo.GetWorkoutByIdAsync(1)).ReturnsAsync(workout);
            _mockRepository.Setup(repo => repo.DeleteWorkoutAsync(1)).ReturnsAsync(workout);

            // Act
            var result = await _service.DeleteWorkoutAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Workout to Delete", result.Title);
            _mockRepository.Verify(repo => repo.DeleteWorkoutAsync(1), Times.Once);
        }
    }
}
