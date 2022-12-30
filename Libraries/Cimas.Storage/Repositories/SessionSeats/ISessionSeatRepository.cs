using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.SessionSeats.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.SessionSeats
{
    public interface ISessionSeatRepository : IBaseRepository<SessionSeat>
    {
        Task<IEnumerable<SessionSeat>> GetSeatsBySessionIdAsync(int sessionId);
        Task<decimal> GetProfit(CountProfitFilter filter);
        Task<IEnumerable<SessionSeat>> GetSessionsInfoAsync(CountProfitFilter filter);
    }
}
