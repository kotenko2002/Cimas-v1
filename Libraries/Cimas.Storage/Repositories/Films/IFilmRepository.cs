using Cimas.Entities.Films;
using Cimas.Storage.Configuration.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Films
{
    public interface IFilmRepository : IBaseRepository<Film>
    {
        Task<IEnumerable<Film>> GetFilmsByComnapyIdAsync(int companyId);
    }
}
