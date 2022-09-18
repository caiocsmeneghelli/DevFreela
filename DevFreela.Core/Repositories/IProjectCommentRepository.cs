using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectCommentRepository
    {
        Task AddAsync(ProjectComment projectComment);
    }
}