using Cimas.Entities.Cinemas;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;

namespace Cimas.Storage.Repositories.Cinemas
{
    public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(CimasDbContext context) : base(context)
        {

        }
    }
}
