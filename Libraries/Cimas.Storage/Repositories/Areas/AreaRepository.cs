using Cimas.Entities.Areas;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Microsoft.Extensions.Logging;

namespace Cimas.Storage.Repositories.Areas
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(CimasDbContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
