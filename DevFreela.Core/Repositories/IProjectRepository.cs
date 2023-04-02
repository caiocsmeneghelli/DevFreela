using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task StartProjectAsync(Project project);
        Task FinishProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
        Task SaveChangesAsync();
    }
}