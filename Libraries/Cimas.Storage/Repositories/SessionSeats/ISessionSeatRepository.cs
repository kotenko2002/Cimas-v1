using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.SessionSeats
{
    public interface ISessionSeatRepository : IBaseRepository<SessionSeat>
    {
        Task<IEnumerable<SessionSeat>> GetSeatsBySessionIdAsync(int sessionId);
    }
}
