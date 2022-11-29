using AutoMapper;
using Cimas.Models.From;
using Cimas.Service.Areas;
using Cimas.Service.Companies.Descriptors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;

        public AreaController(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<int> AddCompany(AreaAddModel model)
        {
            var descriptor = _mapper.Map<AreaAddDescriptor>(model);

            return await _areaService.AddAreaAsync(descriptor);
        }
    }
}
