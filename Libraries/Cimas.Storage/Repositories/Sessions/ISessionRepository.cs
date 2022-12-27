using Cimas.Entities.Sessions;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.Sessions.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Sessions
{
    public interface ISessionRepository : IBaseRepository<Session>
    {
        Task<IEnumerable<SessionView>> GetSessionsByDateAndHallId(DateTime dataTime, int hallId);
    }
}
