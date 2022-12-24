using Cimas.Entities.Halls;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.Halls.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Halls
{
    public interface IHallRepository : IBaseRepository<Hall>
    {
        Task<IEnumerable<HallView>> GetHallsByCinemaIdAsync(int cinemaId);
    }
}
