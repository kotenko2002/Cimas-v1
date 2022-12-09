using Cimas.Entities.Sessions;
using Cimas.Service.Sessions.Descriptors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Sessions
{
    public interface ISessionService
    {
        Task AddSessionAsync(AddSessionDescriptor descriptor);
        Task<IEnumerable<SessionSeat>> GetSeatsBySessionIdAsync(int sessionId);
        Task ChangeSessionSeatsStatusAsync(IEnumerable<ChangeSessionSeatsStatusDescriptor> descriptors);
    }
}
