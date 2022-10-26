using Cimas.Entities.Areas;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;

namespace Cimas.Storage.Repositories.Areas
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(CimasDbContext context) : base(context)
        {

        }
    }
}
