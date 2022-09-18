using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly ProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();
            var projectViewModel = projects
                .Select(reg => new ProjectViewModel(reg.Id, reg.Title, reg.CreatedAt))
                .ToList();

            return projectViewModel;
            
        }
    }
}