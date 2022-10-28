using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task OneProjectExistWithId1_Executed_OneProjectDetailsViewModel()
        {
            // Arrange
            var project = new Project("Titulo de teste", "Descricao de teste", 1, 1, 2000);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(project.Id).Result).Returns(project);

            var getProjectByIdQuery = new GetProjectByIdQuery(project.Id);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectDetailsViewModel = getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // Assert
            Assert.Equal(projectDetailsViewModel.Id, 1);
        }
    }
}