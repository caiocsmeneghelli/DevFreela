using System.Threading.Tasks;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class UpdateProjectCommandHandlerTests
    {
        [Fact]
        public async Task ProjecCommand_Executed_RepositoryCount()
        {
            // Arrange
            var project = new Project("Primeiro titulo", "Descricao de teste", 1, 2, 3000);
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var updateProjectCommand = new UpdateProjectCommand()
            {
                Id = 1,
                Title = "Titulo de teste",
                Description = "Descricao de teste",
                TotalCost = 3000
            };
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(updateProjectCommand.Id).Result).Returns(project);
            var updateProjectCommandHandler = new UpdateProjectCommandHandler(projectRepositoryMock.Object);
            //projectRepositoryMock.Setup(pr => pr.UpdateAsync(It.IsAny<Project>()));

            // Act
            await updateProjectCommandHandler.Handle(updateProjectCommand, new System.Threading.CancellationToken());

            // Assert
            Assert.Equal(project.Title, updateProjectCommand.Title);

        }
    }
}