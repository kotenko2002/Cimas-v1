using AutoMapper;
using Cimas.Entities.Companies;
using Cimas.Models.From;
using Cimas.Service.Companies;
using Cimas.Service.Companies.Descriptors;
using Cimas.Storage.Uow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(
            ICompanyService companyService,
            IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost("add"), AllowAnonymous]
        public async Task<int> AddCompany(AddCompanyModel model)
        {
            var descriptor = _mapper.Map<AddCompanyDescriptor>(model);
            return await _companyService.AddCompanyAsync(descriptor);
        }
    }
}
