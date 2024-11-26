using Moq;
using Xunit;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Services;
using Goal_Flex_ServerSide.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

public class ExerciseServiceTests
{
    private readonly Mock<IExerciseRepository> _mockRepository;
    private readonly IExerciseService _service;

    public ExerciseServiceTests()
    {
        // Create a mock repository instance
        _mockRepository = new Mock<IExerciseRepository>();
        // Create an instance of the ExerciseService using the mocked repository
        _service = new ExerciseService(_mockRepository.Object);
    }

    // Test the CreateExerciseAsync method
    [Fact]
    public async Task CreateExerciseAsync_AddsExercise_WhenValid()
    {
        // Arrange
        var exercise = new Exercise
        {
            Title = "Push-Ups",
            Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
            Instructions = "Start in a plank position, lower your chest to the ground, and push back up.",
            UserId = 1
        };

        // Mock UserExistsAsync to return true
        _mockRepository.Setup(repo => repo.UserExistsAsync(exercise.UserId)).ReturnsAsync(true);
        // Mock CreateExerciseAsync to return the exercise object
        _mockRepository.Setup(repo => repo.CreateExerciseAsync(It.IsAny<Exercise>())).ReturnsAsync(exercise);

        // Act
        var result = await _service.CreateExerciseAsync(exercise);

        // Assert
        Assert.NotNull(result);  // Ensure the result is not null
        Assert.Equal("Push-Ups", result.Title);  // Verify the title
        Assert.Equal("http://dummyimage.com/250x150.png/ff0000/ffffff", result.Image);  // Verify the image URL
        Assert.Equal("Start in a plank position, lower your chest to the ground, and push back up.", result.Instructions);  // Verify instructions
        _mockRepository.Verify(repo => repo.CreateExerciseAsync(It.IsAny<Exercise>()), Times.Once);  // Verify method call
    }

    // Test the CreateExerciseAsync method when the user doesn't exist
    [Fact]
    public async Task CreateExerciseAsync_ThrowsException_WhenUserDoesNotExist()
    {
        // Arrange
        var exercise = new Exercise
        {
            Title = "Push-Ups",
            Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
            Instructions = "Start in a plank position, lower your chest to the ground, and push back up.",
            UserId = 1
        };

        // Mock UserExistsAsync to return false (simulate that the user doesn't exist)
        _mockRepository.Setup(repo => repo.UserExistsAsync(exercise.UserId)).ReturnsAsync(false);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _service.CreateExerciseAsync(exercise)
        );

        Assert.Equal("There is no user with the following id: 1", exception.Message);  // Check for the expected exception message
    }

    // Test the GetExercisesAsync method
    [Fact]
    public async Task GetExercisesAsync_ReturnsExerciseList()
    {
        // Arrange
        var exercises = new List<Exercise>
        {
            new Exercise
            {
                Id = 1,
                Title = "Push-Ups",
                Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
                Instructions = "Start in a plank position, lower your chest to the ground, and push back up.",
                UserId = 1
            }
        };

        // Mock GetExercisesAsync to return the list of exercises
        _mockRepository.Setup(repo => repo.GetExercisesAsync()).ReturnsAsync(exercises);

        // Act
        var result = await _service.GetExercisesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);  // Ensure the result contains one exercise
        Assert.Equal("Push-Ups", result[0].Title);  // Ensure the title matches
    }

    // Test the GetExerciseByIdAsync method when the exercise is found
    [Fact]
    public async Task GetExerciseByIdAsync_ReturnsExercise_WhenValidId()
    {
        // Arrange
        var exercise = new Exercise
        {
            Id = 1,
            Title = "Push-Ups",
            Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
            Instructions = "Start in a plank position, lower your chest to the ground, and push back up.",
            UserId = 1
        };
        _mockRepository.Setup(repo => repo.GetExerciseByIdAsync(1)).ReturnsAsync(exercise);

        // Act
        var result = await _service.GetExerciseByIdAsync(1);

        // Assert
        Assert.NotNull(result);  // Ensure the result is not null
        Assert.Equal("Push-Ups", result.Title);  // Verify the title
        Assert.Equal("http://dummyimage.com/250x150.png/ff0000/ffffff", result.Image);  // Verify the image URL
        Assert.Equal("Start in a plank position, lower your chest to the ground, and push back up.", result.Instructions);  // Verify instructions
    }

    // Test the GetExerciseByIdAsync method when the exercise is not found
    [Fact]
    public async Task GetExerciseByIdAsync_ReturnsNull_WhenInvalidId()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetExerciseByIdAsync(It.IsAny<int>())).ReturnsAsync((Exercise)null);

        // Act
        var result = await _service.GetExerciseByIdAsync(999);  // Non-existing ID

        // Assert
        Assert.Null(result);  // Ensure the result is null
    }

    // Test the UpdateExerciseAsync method
    [Fact]
    public async Task UpdateExerciseAsync_UpdatesExercise_WhenValid()
    {
        // Arrange
        var existingExercise = new Exercise
        {
            Id = 1,
            Title = "Push-Ups",
            Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
            Instructions = "Start in a plank position, lower your chest to the ground, and push back up.",
            UserId = 1
        };
        var updatedExercise = new Exercise
        {
            Id = 1,
            Title = "Squats",
            Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
            Instructions = "Start in a standing position, squat down, and rise back up.",
            UserId = 1
        };

        _mockRepository.Setup(repo => repo.GetExerciseByIdAsync(1)).ReturnsAsync(existingExercise);
        _mockRepository.Setup(repo => repo.UpdateExerciseAsync(updatedExercise, 1)).ReturnsAsync(updatedExercise);

        // Act
        var result = await _service.UpdateExerciseAsync(updatedExercise, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Squats", result.Title);  // Ensure the title was updated
        Assert.Equal("Start in a standing position, squat down, and rise back up.", result.Instructions);  // Ensure instructions were updated
        _mockRepository.Verify(repo => repo.UpdateExerciseAsync(updatedExercise, 1), Times.Once);  // Verify method call
    }

    // Test the DeleteExerciseAsync method
    [Fact]
    public async Task DeleteExerciseAsync_DeletesExercise_WhenValid()
    {
        // Arrange
        var exercise = new Exercise
        {
            Id = 1,
            Title = "Push-Ups",
            Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
            Instructions = "Start in a plank position, lower your chest to the ground, and push back up.",
            UserId = 1
        };
        _mockRepository.Setup(repo => repo.DeleteExerciseAsync(1)).ReturnsAsync(exercise);

        // Act
        var result = await _service.DeleteExerciseAsync(1);

        // Assert
        Assert.NotNull(result);  // Ensure the exercise is not null
        Assert.Equal("Push-Ups", result.Title);  // Ensure the title matches
        _mockRepository.Verify(repo => repo.DeleteExerciseAsync(1), Times.Once);  // Verify method call
    }
}



