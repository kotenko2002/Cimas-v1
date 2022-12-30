using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.SessionSeats.Filters;
using Microsoft.EntityFrameworkCore;
using System;
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
                .Where(seat => seat.SessionId == sessionId)
                .OrderBy(seat => seat.Row).ThenBy(seat => seat.Column)
                .ToListAsync();
        }
        public async Task<decimal> GetProfit(CountProfitFilter filter)
        {
            return await Sourse.Where(seat => seat.DateTime != null && seat.Status == Сommon.Enums.SeatStatus.Occupied
                && seat.DateTime >= filter.StartDateTime && seat.DateTime <= filter.EndDateTime)
                .Include(seat => seat.Session)
                    .ThenInclude(session => session.Hall)
                .Where(seat => seat.Session.Hall.CinemaId == filter.CinemaId)
                .SumAsync(seat => seat.Session.TicketPrice);
        }

        public async Task<IEnumerable<SessionSeat>> GetSessionsInfoAsync(CountProfitFilter filter)
        {
            return await Sourse.Where(seat => seat.DateTime != null && seat.Status == Сommon.Enums.SeatStatus.Occupied
                && seat.DateTime >= filter.StartDateTime && seat.DateTime <= filter.EndDateTime)
                .Include(seat => seat.Session)
                    .ThenInclude(session => session.Hall)
                .Include(seat => seat.Session.Film)
                .Where(seat => seat.Session.Hall.CinemaId == filter.CinemaId)
                .ToListAsync();
        }
    }
}
