using Cimas.Storage.Uow;
using System.Threading.Tasks;

namespace Cimas.Service.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;

        public CompanyService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Entities.Companies.Company> GetCompanyByIdAsync(int id)
        {
            return await _uow.Companies.FindAsync(id);
        }
    }
}
