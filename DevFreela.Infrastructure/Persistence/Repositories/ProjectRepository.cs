using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = await _dbContext.Projects
                .Include(reg => reg.Client)
                .Include(reg => reg.Freelancer)
                .SingleOrDefaultAsync(reg => reg.Id == id);
            return project;
        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartProjectAsync(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task FinishProjectAsync(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}