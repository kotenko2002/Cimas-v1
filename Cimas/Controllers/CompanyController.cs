using Cimas.Entities.Companies;
using Cimas.Models.From;
using Cimas.Service.Companies;
using Cimas.Storage.Uow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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

        [HttpPost("add")]
        public async Task<int> AddCompany(CompanyAddModel model)
        {
            return await _companyService.AddCompanyAsync(model.Name);
        }
    }
}
