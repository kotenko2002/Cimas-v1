using Cimas.Service.Authorization.Descriptors;
using System.Threading.Tasks;

namespace Cimas.Service.Authorization
{
    public interface IAuthService
    {
        Task AddUserAsync(RegistrationDescriptor descriptor);
        Task<string> LoginAndGetTokenAsync(LoginDescriptor descriptor);
    }
}
