using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.SessionSeats
{
    public class SessionSeatRepository : BaseRepository<SessionSeat>, ISessionSeatRepository
    {
        public SessionSeatRepository(CimasDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<SessionSeat>> GetSeatsBySessionIdAsync(int sessionId)
        {
            return await Sourse
                .Where(s => s.SessionId == sessionId)
                .OrderBy(s => s.Row).ThenBy(s => s.Column)
                .ToListAsync();
        }
    }
}
