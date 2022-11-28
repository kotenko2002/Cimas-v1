using Cimas.Entities.Companies;
using System.Threading.Tasks;

namespace Cimas.Service.Companies
{
    public interface ICompanyService
    {
        Task<int> AddCompanyAsync(string name);
        Task<Company> GetCompanyByIdAsync(int id);
    }
}
