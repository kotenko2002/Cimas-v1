﻿using Cimas.Entities.Users;
using Cimas.Storage.Uow;
using Cimas.Сommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task FireUserAsync(int userId)
        {
            var user = await _uow.UserRepository.FindAsync(userId);

            if(user == null)
            {
                throw new NotFoundException("User with such Id doesn't exist.");
            }

            user.IsFired = true;
            await _uow.CompleteAsync();
        }

        public async Task<User> GetUserInfoAsync(int userId)
        {
            return await _uow.UserRepository.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsersByCompanyId(int companyId)
        {
            return await _uow.UserRepository.GetUsersByCompanyId(companyId);
        }
    }
}
