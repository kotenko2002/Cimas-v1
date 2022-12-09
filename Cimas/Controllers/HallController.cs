using AutoMapper;
using Cimas.Entities.Halls;
using Cimas.Models.From;
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
        public HallController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task AddHall(AddHallModel model)
        {
            // add hall
        }

        [HttpDelete("del")]
        public async Task DeleteHall(int hallId)
        {
            // delete hall
        }

        [HttpGet("items/{cinemaId}")]
        public async Task<IEnumerable<Hall>> GetHallsByCinemaId(int cinemaId)
        {
            return null;
            // get all halls
        }
    }
}
