using Cimas.Entities.Halls;
using Cimas.Storage.Configuration.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Halls
{
    public interface IHallRepository : IBaseRepository<Hall>
    {
        Task<IEnumerable<Hall>> GetHallsByCinemaIdAsync(int cinemaId);
    }
}
