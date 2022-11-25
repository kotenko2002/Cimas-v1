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
            if (await _uow.Users.UserWithThisLoginExists(descriptor.Login))
            {
                throw new Exception("User with such username is already exist.");
            }

            CreatePasswordHash(descriptor.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User()
            {
                CompanyId = descriptor.CompanyId,
                AreaId = descriptor.AreaId,
                Login = descriptor.Login,
                PasswordHash = JsonConvert.SerializeObject(passwordHash),
                PasswordSalt = JsonConvert.SerializeObject(passwordSalt),
                Name = descriptor.Name,
                Role = descriptor.Role
            };

            _uow.Users.Add(user);
            await _uow.CompleteAsync();
        }

        public async Task<string> LoginAndGetTokenAsync(LoginDescriptor descriptor)
        {
            var user = await _uow.Users.FindByLoginAsync(descriptor.Login);
            if (user == null)
            {
                throw new Exception("User not found.");
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
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString())
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
