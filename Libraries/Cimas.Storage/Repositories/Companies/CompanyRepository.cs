using Cimas.Entities.Companies;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;

namespace Cimas.Storage.Repositories.Companies
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(CimasDbContext context) : base(context)
        {

        }
    }
}
