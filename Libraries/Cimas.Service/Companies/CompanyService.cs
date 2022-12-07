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

        public async Task<int> AddCompanyAsync(string name)
        {
            Company company = new Company() { Name = name };
            _uow.CompanyRepository.Add(company);
            await _uow.CompleteAsync();

            return company.Id;
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _uow.CompanyRepository.FindAsync(id);
        }
    }
}
