using System.Threading.Tasks;

namespace Cimas.Service.Company
{
    public interface ICompanyService
    {
        public Task<Cimas.Entities.Companies.Company> GetCompanyByIdAsync(int id);
    }
}
