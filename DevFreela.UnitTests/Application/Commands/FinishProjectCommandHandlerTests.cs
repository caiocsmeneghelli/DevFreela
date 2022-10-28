using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class FinishProjectCommandHandlerTests
    {
        [Fact]
        public async Task IdProject_Executed_ProjectStatusEqualFinished()
        {
            // Arrange
            var finishProjectCommand = new FinishProjectCommand(1);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepositoryMock.Object);
            projectRepositoryMock.Setup(pr => pr.FinishProjectAsync(It.IsAny<Project>()));

            // Necessario para verificar com FinishProjectAsync
            var project = new Project("Titulo de teste", "Teste", 1, 1, 2000);
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(finishProjectCommand.Id).Result).Returns(project);

            // Para finalizar um Project ele deve estar iniciado
            project.Start();

            // Act
            await finishProjectCommandHandler.Handle(finishProjectCommand, new System.Threading.CancellationToken());

            // Assert
            Assert.Equal(project.Status, DevFreela.Core.Enums.ProjectStatusEnum.Finished);
        }
    }
}