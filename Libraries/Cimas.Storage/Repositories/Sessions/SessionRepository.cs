using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.Sessions.Filter;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Session>> GetSessionsByRange(SessionsByRangeFilter descriptor)
        {
            return await Sourse.Where(item => item.StartDateTime.Date >= descriptor.From.Date
                && item.EndDateTime.Date < descriptor.To.Date).ToListAsync();
        }
    }
}
