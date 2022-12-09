using Cimas.Entities.Films;
using Cimas.Service.Films.Descriptors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Films
{
    public interface IFilmService
    {
        Task<int> AddFilmAsync(AddFilmDescriptor descriptor);
        Task DeleteFilmAsync(int filmId);
        Task<IEnumerable<Film>> GetFilmsByComnapyIdAsync(int companyId);
    }
}
