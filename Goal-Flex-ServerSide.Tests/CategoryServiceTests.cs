using Moq;
using Xunit;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Services;
using Goal_Flex_ServerSide.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryRepository> _mockRepository;
    private readonly ICategoryService _service;

    public CategoryServiceTests()
    {
        _mockRepository = new Mock<ICategoryRepository>();
        _service = new CategoryService(_mockRepository.Object);
    }

    // Test GetCategoriesAsync when there are no categories
    [Fact]
    public async Task GetCategoriesAsync_ReturnsEmptyList_WhenNoCategories()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetCategoriesAsync()).ReturnsAsync(new List<Category>());

        // Act
        var result = await _service.GetCategoriesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);  // Assert that the result is an empty list
    }

    // Test CreateCategoryAsync when the category is successfully created
    [Fact]
    public async Task CreateCategoryAsync_CreatesCategory_WhenValid()
    {
        // Arrange
        var newCategory = new Category
        {
            Name = "Strength Training"
        };

        var createdCategory = new Category
        {
            Id = 1,
            Name = "Strength Training"
        };

        _mockRepository.Setup(repo => repo.CreateCategoryAsync(It.IsAny<Category>())).ReturnsAsync(createdCategory);

        // Act
        var result = await _service.CreateCategoryAsync(newCategory);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Strength Training", result.Name);  // Assert that the category name matches
        _mockRepository.Verify(repo => repo.CreateCategoryAsync(It.IsAny<Category>()), Times.Once);

    }

    // Test UpdateCategoryAsync when the category is successfully updated
    [Fact]
    public async Task UpdateCategoryAsync_UpdatesCategory_WhenValid()
    {
        // Arrange
        var existingCategory = new Category
        {
            Id = 1,
            Name = "Strength Training"
        };
        var updatedCategory = new Category
        {
            Id = 1,
            Name = "Cardio Training"
        };

        _mockRepository.Setup(repo => repo.UpdateCategoryAsync(updatedCategory, 1)).ReturnsAsync(updatedCategory);

        // Act
        var result = await _service.UpdateCategoryAsync(updatedCategory, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Cardio Training", result.Name);  // Assert that the category name is updated
        _mockRepository.Verify(repo => repo.UpdateCategoryAsync(updatedCategory, 1), Times.Once);  // Verify that UpdateCategoryAsync was called
    }

    // Test DeleteCategoryAsync when the category doesn't exist
    [Fact]
    public async Task DeleteCategoryAsync_ReturnsNull_WhenCategoryDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.DeleteCategoryAsync(It.IsAny<int>())).ReturnsAsync((Category)null);

        // Act
        var result = await _service.DeleteCategoryAsync(999);  // Non-existing ID

        // Assert
        Assert.Null(result);  // Assert that the result is null (no category to delete)
    }

    // Test DeleteCategoryAsync when the category exists
    [Fact]
    public async Task DeleteCategoryAsync_DeletesCategory_WhenValid()
    {
        // Arrange
        var category = new Category
        {
            Id = 1,
            Name = "Strength Training"
        };

        _mockRepository.Setup(repo => repo.DeleteCategoryAsync(1)).ReturnsAsync(category);

        // Act
        var result = await _service.DeleteCategoryAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Strength Training", result.Name);  // Assert that the category was deleted and returned correctly
        _mockRepository.Verify(repo => repo.DeleteCategoryAsync(1), Times.Once);  // Verify that DeleteCategoryAsync was called
    }
}

