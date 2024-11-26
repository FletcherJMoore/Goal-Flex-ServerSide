using Moq;
using Xunit;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Services;
using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MealServiceTests
{
    private readonly Mock<IMealRepository> _mockRepository;
    private readonly IMealService _service;

    public MealServiceTests()
    {
        _mockRepository = new Mock<IMealRepository>();
        _service = new MealService(_mockRepository.Object);
    }

    // Test GetMealsAsync when there are no meals
    [Fact]
    public async Task GetMealsAsync_ReturnsEmptyList_WhenNoMeals()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetMealsAsync()).ReturnsAsync(new List<Meal>());

        // Act
        var result = await _service.GetMealsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);  // Assert that the result is an empty list
    }

    // Test GetMealByIdAsync when meal is not found
    [Fact]
    public async Task GetMealByIdAsync_ReturnsNull_WhenMealDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetMealByIdAsync(It.IsAny<int>())).ReturnsAsync((Meal)null);

        // Act
        var result = await _service.GetMealByIdAsync(999);  // Non-existing ID

        // Assert
        Assert.Null(result);  // Assert that the result is null
    }

    // Test CreateMealAsync when the user does not exist
    [Fact]
    public async Task CreateMealAsync_ThrowsException_WhenUserDoesNotExist()
    {
        // Arrange
        var meal = new Meal
        {
            Title = "Pasta",
            Recipe = "Boil pasta and add sauce",
            Calories = "400 kcal",
            Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
            UserId = 99  // Non-existing user
        };

        // Mock UserExistsAsync to return false
        _mockRepository.Setup(repo => repo.UserExistsAsync(meal.UserId)).ReturnsAsync(false);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _service.CreateMealAsync(meal)
        );

        Assert.Equal($"There is no user with the following id: {meal.UserId}", exception.Message);
    }

    // Test UpdateMealAsync when the meal exists and is updated
    [Fact]
    public async Task UpdateMealAsync_UpdatesMeal_WhenValid()
    {
        // Arrange
        var existingMeal = new Meal
        {
            Id = 1,
            Title = "Grilled Chicken Salad",
            Image = "http://dummyimage.com/250x150.png/ff5733/ffffff",
            Calories = "350 kcal",
            Recipe = "Grill chicken breast and serve with mixed greens, cherry tomatoes, and vinaigrette.",
            UserId = 1
        };
        var updatedMeal = new Meal
        {
            Id = 1,
            Title = "Greek Salad with Chicken",
            Image = "http://dummyimage.com/250x150.png/57ff33/ffffff",
            Calories = "400 kcal",
            Recipe = "Grill chicken breast and serve with mixed greens, cucumbers, and feta cheese.",
            UserId = 1
        };

        _mockRepository.Setup(repo => repo.GetMealByIdAsync(1)).ReturnsAsync(existingMeal);
        _mockRepository.Setup(repo => repo.UpdateMealAsync(updatedMeal, 1)).ReturnsAsync(updatedMeal);

        // Act
        var result = await _service.UpdateMealAsync(updatedMeal, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Greek Salad with Chicken", result.Title);  // Assert that the title was updated
        Assert.Equal("http://dummyimage.com/250x150.png/57ff33/ffffff", result.Image);  // Assert that the image was updated
        Assert.Equal("400 kcal", result.Calories);  // Assert that the calories were updated
        Assert.Equal("Grill chicken breast and serve with mixed greens, cucumbers, and feta cheese.", result.Recipe);  // Assert that the recipe was updated
        _mockRepository.Verify(repo => repo.UpdateMealAsync(updatedMeal, 1), Times.Once);  // Verify that the UpdateMealAsync method was called
    }

    // Test DeleteMealAsync when the meal doesn't exist
    [Fact]
    public async Task DeleteMealAsync_ReturnsNull_WhenMealDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.DeleteMealAsync(It.IsAny<int>())).ReturnsAsync((Meal)null);

        // Act
        var result = await _service.DeleteMealAsync(999);  // Non-existing ID

        // Assert
        Assert.Null(result);  // Assert that the result is null (no meal to delete)
    }

    // Test DeleteMealAsync when the meal exists
    [Fact]
    public async Task DeleteMealAsync_DeletesMeal_WhenValid()
    {
        // Arrange
        var meal = new Meal
        {
            Id = 1,
            Title = "Pasta",
            Recipe = "Boil pasta and add sauce",
            Calories = "400 kcal",
            Image = "http://dummyimage.com/250x150.png/ff0000/ffffff",
            UserId = 1
        };

        _mockRepository.Setup(repo => repo.DeleteMealAsync(1)).ReturnsAsync(meal);

        // Act
        var result = await _service.DeleteMealAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Pasta", result.Title);  // Assert that the meal was deleted and returned correctly
        _mockRepository.Verify(repo => repo.DeleteMealAsync(1), Times.Once);  // Verify that the DeleteMealAsync method was called
    }
}


