using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetUserById;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetUserByIdQueryHandlerTests
    {
        [Fact]
        public async Task OneUserExistsWithId_Execute_UserViewModel()
        {
            // Arrange
            var user = new User("Caio Cesar Serrano Meneghelli", "caiocsmeneghelli@gmail.com",
             new DateTime(1995, 12, 15), "Password", "client");
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(ur => ur.GetUserByIdAsync(user.Id).Result).Returns(user);

            var getUserByIdQuery = new GetUserByIdQuery(user.Id);
            var getUserByIdQueryHandler = new GetUserByIdQueryHandler(userRepositoryMock.Object);

            // Act
            var userViewModel = await getUserByIdQueryHandler.Handle(getUserByIdQuery, new System.Threading.CancellationToken());

            // Assert
            Assert.Equal(user.Role, userViewModel.Role);
            Assert.NotNull(userViewModel);
            userRepositoryMock.Verify(ur => ur.GetUserByIdAsync(user.Id), Times.Once);
        }
    }
}