using Xunit;
using CitasSalud.Models;
using CitasSalud.Data.Repositories;
using Moq;

namespace TestAPICitasSalud
{
    public class UnitTest1
    {
        [Fact]
        public void GetById_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(new User
            {
                IdUser = 4,
                UserName = "ANDREA",
                UserLastName = "TORO",
                UserPhone = "314346577",
                UserEmail = "correo@gmail.com"
            });

            var userRepository = mockRepo.Object;

            // Act
            var user = userRepository.GetById(1).Result;

            // Assert
            Assert.NotNull(user);
            Assert.Equal("ANDREA", user.UserName);

        }
    }
}