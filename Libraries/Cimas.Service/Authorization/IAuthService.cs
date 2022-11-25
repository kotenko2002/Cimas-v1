using Cimas.Service.Authorization.Descriptors;
using System.Threading.Tasks;

namespace Cimas.Service.Authorization
{
    public interface IAuthService
    {
        //void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        //bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        //string CreateToken(User user);

        Task AddUserAsync(RegistrationDescriptor descriptor);
    }
}
