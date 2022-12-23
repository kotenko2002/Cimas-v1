using Cimas.Entities.Companies;
using Cimas.Service.Companies.Descriptors;
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

        public async Task<int> AddCompanyAsync(AddCompanyDescriptor descriptor)
        {
            Company company = new Company() { Name = descriptor.Name };
            _uow.CompanyRepository.Add(company);
            await _uow.CompleteAsync();

            return company.Id;
        }

        public async Task DeletecompanyAsync(int companyId)
        {
            var company = await _uow.CompanyRepository.FindAsync(companyId);

            _uow.CompanyRepository.Remove(company);
            await _uow.CompleteAsync();
        }
    }
}
