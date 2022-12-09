using Cimas.Entities.Halls;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.HallSeats
{
    public class HallSeatRepository : BaseRepository<HallSeat>, IHallSeatRepository
    {
        public HallSeatRepository(CimasDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<HallSeat>> GetAllSeatsByHallId(int hallId)
        {
            return await Sourse.Where(item => item.HallId == hallId).ToListAsync();
        }
    }
}
