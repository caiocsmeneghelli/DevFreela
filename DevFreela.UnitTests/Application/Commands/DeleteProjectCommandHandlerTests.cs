using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class DeleteProjectCommandHandlerTests
    {
        [Fact]
        public async Task OneProject_Executed_StatusCancelled()
        {
            // Arrange
            var deleteProjectCommand = new DeleteProjectCommand(1);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);
            projectRepositoryMock.Setup(pr => pr.DeleteProjectAsync(It.IsAny<Project>()));
            
            // Necessario para verificar com DeleteProjectAsync
            var project = new Project("Titulo de teste", "teste", 1, 1, 2000);
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(deleteProjectCommand.Id).Result).Returns(project);

            // Act
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new System.Threading.CancellationToken());

            // Assert
            Assert.Equal(DevFreela.Core.Enums.ProjectStatusEnum.Cancelled, project.Status);
        }
    }
}