using System.Collections.Generic;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public void ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Titulo de teste 1", "Descricao de teste", 1, 2, 1000),
                new Project("Titulo de teste 2", "Descricao de teste", 3, 4, 1000),
                new Project("Titulo de teste 3", "Descricao de teste", 5, 6, 1000),
            };
            var projectRepository = new Mock<IProjectRepository>();
            projectRepository.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            // Act

            // Assert
        }
    }
}