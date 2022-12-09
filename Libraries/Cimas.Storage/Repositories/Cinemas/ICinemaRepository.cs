using Cimas.Entities.Cinemas;
using Cimas.Storage.Configuration.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Cinemas
{
    public interface ICinemaRepository : IBaseRepository<Cinema>
    {
        Task<IEnumerable<Cinema>> GetCinemasByComnapyIdAsync(int companyId);
    }
}
