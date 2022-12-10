using AutoMapper;
using Cimas.Entities.Halls;
using Cimas.Models.From;
using Cimas.Service.Halls;
using Cimas.Service.Halls.Descriptors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Authorize]
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

        [HttpPost("add")]
        public async Task<int> AddHall(AddHallModel model)
        {
            var descriptor = _mapper.Map<AddHallDescriptor>(model);

            return await _hallService.AddHallAsync(descriptor);
        }

        [HttpDelete("del/{hallId}")]
        public async Task DeleteHall(int hallId)
        {
            await _hallService.DeleteHallAsync(hallId);
        }

        [HttpGet("items/{cinemaId}")]
        public async Task<IEnumerable<Hall>> GetHallsByCinemaId(int cinemaId)
        {
            return await _hallService.GetHallsByCinemaIdAsync(cinemaId);
        }
    }
}
