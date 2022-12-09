using Cimas.Entities.Cinemas;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Cinemas
{
    public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(CimasDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Cinema>> GetCinemasByComnapyIdAsync(int companyId)
        {
            return await Sourse.Where(item => item.CompanyId == companyId).ToListAsync();
        }
    }
}
