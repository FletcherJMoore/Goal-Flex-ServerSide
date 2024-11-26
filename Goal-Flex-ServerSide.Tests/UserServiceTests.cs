using Goal_Flex_ServerSide.Interfaces;
using Goal_Flex_ServerSide.Models;
using Goal_Flex_ServerSide.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Goal_Flex_ServerSide.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        // Test: CheckUserAsync should return a user if the UID is found
        [Fact]
        public async Task CheckUserAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userUid = "1";
            var mockUser = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Username = "johndoe",
                Uid = userUid,
                Image = "http://example.com/image.png"
            };

            _mockUserRepository.Setup(repo => repo.CheckUserAsync(userUid)).ReturnsAsync(mockUser);

            // Act
            var result = await _userService.CheckUserAsync(userUid);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userUid, result.Uid);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
        }

        // Test: CheckUserAsync should return null if the user does not exist
        [Fact]
        public async Task CheckUserAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userUid = "999";
            _mockUserRepository.Setup(repo => repo.CheckUserAsync(userUid)).ReturnsAsync((User)null);

            // Act
            var result = await _userService.CheckUserAsync(userUid);

            // Assert
            Assert.Null(result);
        }

        // Test: GetUserByIdAsync should return a user if the userId is found
        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var mockUser = new User
            {
                Id = userId,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Username = "janesmith",
                Uid = "2",
                Image = "http://example.com/image2.png"
            };

            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(mockUser);

            // Act
            var result = await _userService.GetUserByIdAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal("Jane", result.FirstName);
            Assert.Equal("Smith", result.LastName);
        }
    }
}

        // Test: GetUserByIdAsync should return null if the userI

