using AutoMapper;
using Cimas.Entities.Sessions;
using Cimas.Models.From;
using Cimas.Service.Sessions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;
        public SessionController(
            ISessionService sessionService,
            IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task AddSession(AddSessionModel model)
        {
            // add session
        }

        [HttpDelete("del")]
        public async Task DeleteSession(int sessionId)
        {
            // delete session
        }

        [HttpGet("bydiapazon")]
        public async Task<IEnumerable<Session>> GetSessionsByDiapazon(int sessionId)
        {
            return null;
            // get sessions by date diapazon (week)
        }

    }
}
