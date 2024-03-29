﻿using Cimas.Entities.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Users
{
    public interface IUserService
    {
        Task<User> GetUserInfoAsync(int userId);
        Task<IEnumerable<User>> GetUsersByCompanyId(int companyId);
        Task FireUserAsync(int userId);
    }
}
