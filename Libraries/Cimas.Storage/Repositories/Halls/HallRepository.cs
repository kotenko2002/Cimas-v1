using Cimas.Entities.Halls;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
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

        public async Task<IEnumerable<Hall>> GetHallsByCinemaIdAsync(int cinemaId)
        {
            return await Sourse.Where(item => item.CinemaId == cinemaId).ToListAsync();
        }
    }
}
