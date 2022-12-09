using Cimas.Entities.Halls;
using Cimas.Storage.Configuration.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.HallSeats
{
    public interface IHallSeatRepository : IBaseRepository<HallSeat>
    {
        Task<IEnumerable<HallSeat>> GetAllSeatsByHallId(int hallId);
    }
}
