using Cimas.Entities.Halls;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.Halls.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Halls
{
    public class HallRepository : BaseRepository<Hall>, IHallRepository
    {
        public HallRepository(CimasDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<HallView>> GetHallsByCinemaIdAsync(int cinemaId)
        {
            return await Sourse.Where(item => item.CinemaId == cinemaId)
                .Include(item => item.HallSeats)
                .Select(item => new HallView() { Id = item.Id, Name = item.Name, SeatsCount = item.HallSeats.Count})
                .ToListAsync();
        }
    }
}
