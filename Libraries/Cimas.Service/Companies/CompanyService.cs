using Cimas.Entities.Companies;
using Cimas.Storage.Uow;
using System.Threading.Tasks;

namespace Cimas.Service.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;

        public CompanyService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _uow.Companies.FindAsync(id);
        }
    }
}
