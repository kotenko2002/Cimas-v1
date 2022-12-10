using Cimas.Entities.Sessions;
using Cimas.Service.Sessions.Descriptors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Sessions
{
    public interface ISessionService
    {
        Task<int> AddSessionAsync(AddSessionDescriptor descriptor);
        Task DeleteSessionAsync(int sessionId);
        Task<IEnumerable<SessionSeat>> GetSeatsBySessionIdAsync(int sessionId);
        Task<IEnumerable<Session>> GetSessionsByRange(SessionsByRangeDescriptor descriptor);
        Task ChangeSessionSeatsStatusAsync(int sessionId, IEnumerable<ChangeSessionSeatStatusDescriptor> descriptors);
    }
}
