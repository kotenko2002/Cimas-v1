﻿using Cimas.Entities.Users;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cimas.Storage.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CimasDbContext context) : base(context)
        {

        }

        public async Task<User> FindByLoginAsync(string login)
        {
            return await Sourse.FirstOrDefaultAsync(user => user.Login == login);
        }

        public async Task<bool> UserWithThisLoginExists(string login)
        {
            return await Sourse.FirstOrDefaultAsync(user => user.Login == login) != null;
        }

        public async Task<IEnumerable<User>> GetUsersByCompanyId(int comapnyId)
        {
            return await Sourse.Where(user => user.CompanyId == comapnyId && !user.IsFired)
                .ToListAsync();
        }
    }
}
