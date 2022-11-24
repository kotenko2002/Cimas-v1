using Cimas.Entities.Companies;
using System.Threading.Tasks;

namespace Cimas.Service.Companies
{
    public interface ICompanyService
    {
        public Task<Company> GetCompanyByIdAsync(int id);
    }
}
