using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;

namespace Cimas.Storage.Repositories.SessionSeats
{
    public class SessionSeatRepository : BaseRepository<SessionSeat>, ISessionSeatRepository
    {
        public SessionSeatRepository(CimasDbContext context) : base(context)
        {

        }
    }
}
