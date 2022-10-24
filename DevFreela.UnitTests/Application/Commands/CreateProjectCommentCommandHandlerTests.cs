using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_VerifyExecutionAtLeastOneTime(){
            // Arrange
            var projectCommandRepositoryMock = new Mock<IProjectCommentRepository>();
            var createProjectCommentCommand = new CreateProjectCommentCommand(){
                Content = "Comentario de teste",
                IdUser = 1,
                IdProject = 1
            };

            var createProjectCommentCommandHandler = new CreateProjectCommentCommandHandler(projectCommandRepositoryMock.Object);
            // Act
            await createProjectCommentCommandHandler.Handle(createProjectCommentCommand, new System.Threading.CancellationToken());

            // Assert
            
            projectCommandRepositoryMock.Verify(pcr => pcr.AddAsync(It.IsAny<ProjectComment>()), Times.AtLeast(1));
        }
    }
}