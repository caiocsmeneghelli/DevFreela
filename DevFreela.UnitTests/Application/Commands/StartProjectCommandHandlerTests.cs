using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class StartProjectCommandHandlerTests
    {
        [Fact]
        public async Task IdProject_Executed_ProjectStatusEqualInProgress()
        {
            // Arrange
            var startProjectCommand = new StartProjectCommand(1);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var startProjectCommandHandler = new StartProjectCommandHandler(projectRepositoryMock.Object);
            projectRepositoryMock.Setup(pr => pr.StartProjectAsync(It.IsAny<Project>()));
            
            // Necessario para verificar com StartProjectAsync
            var project = new Project("Titulo de teste", "teste", 1, 1, 3000);
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(startProjectCommand.Id).Result).Returns(project);

            // Act
            await startProjectCommandHandler.Handle(startProjectCommand, new System.Threading.CancellationToken());
        
            // Assert
            Assert.Equal(project.Status, DevFreela.Core.Enums.ProjectStatusEnum.InProgress);
        }
    }
}