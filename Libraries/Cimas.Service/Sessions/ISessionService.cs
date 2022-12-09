using Cimas.Service.Sessions.Descriptors;
using System.Threading.Tasks;

namespace Cimas.Service.Sessions
{
    public interface ISessionService
    {
        Task AddSessionAsync(AddSessionDescriptor descriptor); 
    }
}
