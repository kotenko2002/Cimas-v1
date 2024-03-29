﻿using Cimas.Entities.Users;
using Cimas.Storage.Configuration.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> UserWithThisLoginExists(string login);
        Task<User> FindByLoginAsync(string login);
        Task<IEnumerable<User>> GetUsersByCompanyId(int comapnyId);
    }
}
