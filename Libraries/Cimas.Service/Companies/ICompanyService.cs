using Cimas.Entities.Companies;
using Cimas.Service.Companies.Descriptors;
using System.Threading.Tasks;

namespace Cimas.Service.Companies
{
    public interface ICompanyService
    {
        Task<int> AddCompanyAsync(AddCompanyDescriptor descriptor);
        Task DeletecompanyAsync(int companyId);
    }
}
