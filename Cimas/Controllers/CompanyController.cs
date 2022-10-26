using Cimas.Entities.Companies;
using Cimas.Service.Company;
using Cimas.Storage.Uow;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Route("company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<Company> GetCompanyById(int id)
        {
            return await _companyService.GetCompanyByIdAsync(id);
        }
    }
}
