using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeSkillsExist_Executed_ReturnThreeSkillsViewModel()
        {
            // Arrange
            var skills = new List<Skill>()
            {
                new Skill("Faz comida boa"),
                new Skill("C#"),
                new Skill("Skill de teste")
            };
            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(sr => sr.GetAllAsync().Result).Returns(skills);
            
            var getAllSkillsQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            // Act
            var skillViewModelList = await getAllSkillsQueryHandler.Handle(getAllSkillsQuery, new System.Threading.CancellationToken());

            // Assert
            Assert.NotNull(skillViewModelList);
            Assert.Equal(skillViewModelList.Count, skills.Count);
            skillRepositoryMock.Verify(sr => sr.GetAllAsync().Result, Times.Once);

        }
        
    }
}