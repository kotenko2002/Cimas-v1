using Cimas.Entities.Cinemas;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Cinemas
{
    public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(CimasDbContext context) : base(context)
        {

        }
    }
}
