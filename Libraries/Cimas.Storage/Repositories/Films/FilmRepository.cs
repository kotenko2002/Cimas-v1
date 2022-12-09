using Cimas.Entities.Films;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Films
{
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        public FilmRepository(CimasDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Film>> GetFilmsByComnapyIdAsync(int companyId)
        {
            return await Sourse.Where(item => item.CompanyId == companyId).ToListAsync();
        }
    }
}
