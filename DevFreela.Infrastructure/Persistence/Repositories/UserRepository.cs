using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(User user)
        {
            _dbContext.Users.AddAsync(user);
            return user.Id;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                .Users
                .SingleOrDefaultAsync(reg => reg.Email == email && reg.Password == passwordHash);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(reg => reg.Id == id);
            return user;
        }
    }
}