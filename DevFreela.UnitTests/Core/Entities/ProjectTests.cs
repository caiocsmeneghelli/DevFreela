using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome de teste", "Descricao de teste", 1, 2, 1000);
            Assert.Equal(project.Status, ProjectStatusEnum.Created);
            Assert.Null(project.StartedAt);
            project.Start();
            Assert.Equal(project.Status, ProjectStatusEnum.InProgress);
            Assert.NotNull(project.StartedAt);
        }
    }
}