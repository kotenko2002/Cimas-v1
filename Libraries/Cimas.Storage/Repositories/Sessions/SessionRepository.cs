using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.Sessions.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Sessions
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public SessionRepository(CimasDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<SessionView>> GetSessionsByDateAndHallId(DateTime data, int hallId)
        {
            return await Sourse
                .Where(item => item.StartDateTime.Date == data.Date && item.HallId == hallId)
                .Select(item => new SessionView()
                {
                    Id = item.Id,
                    FilmId = item.FilmId,
                    StartDateTime = item.StartDateTime,
                    EndDateTime = item.EndDateTime,
                    TicketPrice = item.TicketPrice,
                })
                .ToListAsync();
        }
    }
}
