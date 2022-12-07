using Cimas.Entities.Films;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;

namespace Cimas.Storage.Repositories.Films
{
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        public FilmRepository(CimasDbContext context) : base(context)
        {

        }
    }
}
