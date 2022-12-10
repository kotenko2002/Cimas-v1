using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.Sessions.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Sessions
{
    public interface ISessionRepository : IBaseRepository<Session>
    {
        Task<IEnumerable<Session>> GetSessionsByRange(SessionsByRangeFilter descriptor);
    }
}
