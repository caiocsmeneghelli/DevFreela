using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommandCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectCommentRepository _projectCommentRepository;

        public CreateCommandCommandHandler(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(
                request.Content,
                request.IdProject,
                request.IdUser
            );
            await _projectCommentRepository.AddAsync(comment);
            return Unit.Value;
        }
    }
}