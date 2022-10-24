using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUseId()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();
            var createUserCommand = new CreateUserCommand()
            {
                FullName = "Caio Cesar Serrano Meneghelli",
                Email = "caiocsmeneghelli@gmail.com",
                Birthdate = new DateTime(1995, 12, 15),
                Password = "PasswordForTests",
                Role = "Freelancer"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object,
                authServiceMock.Object);

            // Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new System.Threading.CancellationToken());

            // Assert
            Assert.True(id >= 0);
        }
    }
}