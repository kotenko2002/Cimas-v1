using AutoMapper;
using Cimas.Models.From;
using Cimas.Service.Halls;
using Cimas.Service.Halls.Descriptors;
using Cimas.Storage.Repositories.Halls.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Authorize(Roles = "CompanyAdmin,Worker")]
    [ApiController]
    [Route("[controller]")]
    public class HallController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHallService _hallService;
        public HallController(
            IMapper mapper,
            IHallService hallService)
        {
            _mapper = mapper;
            _hallService = hallService;
        }

        [HttpPost("add"), Authorize(Roles = "CompanyAdmin")]
        public async Task<int> AddHall(AddHallModel model)
        {
            var descriptor = _mapper.Map<AddHallDescriptor>(model);

            return await _hallService.AddHallAsync(descriptor);
        }

        [HttpDelete("del/{hallId}"), Authorize(Roles = "CompanyAdmin")]
        public async Task DeleteHall(int hallId)
        {
            await _hallService.DeleteHallAsync(hallId);
        }

        [HttpGet("items/{cinemaId}")]
        public async Task<IEnumerable<HallView>> GetHallsByCinemaId(int cinemaId)
        {
            return await _hallService.GetHallsByCinemaIdAsync(cinemaId);
        }
    }
}
