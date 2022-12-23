using Cimas.Storage.Uow;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Cimas.Service.Authorization.Descriptors;
using Cimas.Entities.Users;
using Newtonsoft.Json;
using Cimas.Сommon.Exceptions;

namespace Cimas.Service.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _uow;
        public AuthService(IConfiguration configuration, IUnitOfWork uow)
        {
            _configuration = configuration;
            _uow = uow;
        }

        public async Task AddUserAsync(RegistrationDescriptor descriptor)
        {
            if (await _uow.UserRepository.UserWithThisLoginExists(descriptor.Login))
            {
                throw new NotFoundException("User with such Login is already exist.");
            }

            if(await _uow.CompanyRepository.FindAsync(descriptor.CompanyId) == null)
            {
                throw new NotFoundException("Company with such id doesn't exist.");
            }

            CreatePasswordHash(descriptor.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User()
            {
                CompanyId = descriptor.CompanyId,
                Login = descriptor.Login,
                PasswordHash = JsonConvert.SerializeObject(passwordHash),
                PasswordSalt = JsonConvert.SerializeObject(passwordSalt),
                Name = descriptor.Name,
                Role = descriptor.Role
            };

            _uow.UserRepository.Add(user);
            await _uow.CompleteAsync();
        }

        public async Task<string> LoginAndGetTokenAsync(LoginDescriptor descriptor)
        {
            var user = await _uow.UserRepository.FindByLoginAsync(descriptor.Login);
            if (user == null)
            {
                throw new Exception("User with such Login not found.");
            }

            if(user.IsFired)
            {
                throw new Exception("You have been fired, now you can't log into your account.");
            }

            if (!VerifyPasswordHash(descriptor.Password,
                    JsonConvert.DeserializeObject<byte[]>(user.PasswordHash),
                    JsonConvert.DeserializeObject<byte[]>(user.PasswordSalt)))
            {
                throw new Exception("Wrong password.");
            }

            return CreateToken(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("companyId", user.CompanyId.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
