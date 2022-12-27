using Cimas.Entities.Sessions;
using Cimas.Service.Sessions.Descriptors;
using Cimas.Storage.Repositories.Sessions.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Sessions
{
    public interface ISessionService
    {
        Task<int> AddSessionAsync(AddSessionDescriptor descriptor);
        Task DeleteSessionAsync(int sessionId);
        Task<IEnumerable<IEnumerable<SessionSeat>>> GetSeatsBySessionIdAsync(int sessionId);
        Task<IEnumerable<SessionView>> GetSessionsByDateAndHallId(SessionsByRangeDescriptor descriptor);
        Task ChangeSessionSeatsStatusAsync(IEnumerable<ChangeSessionSeatStatusDescriptor> descriptors);
    }
}
