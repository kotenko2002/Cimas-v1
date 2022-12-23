using AutoMapper;
using Cimas.Entities.Sessions;
using Cimas.Models.From;
using Cimas.Models.To;
using Cimas.Service.Sessions;
using Cimas.Service.Sessions.Descriptors;
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
        public async Task<int> AddSession(AddSessionModel model)
        {
            var descriptor = _mapper.Map<AddSessionDescriptor>(model);
            return await _sessionService.AddSessionAsync(descriptor);
        }

        [HttpDelete("del/{sessionId}")]
        public async Task DeleteSession(int sessionId)
        {
            await _sessionService.DeleteSessionAsync(sessionId);
        }

        [HttpGet("items/byRange")]
        public async Task<IEnumerable<Session>> GetSessionsByRange([FromQuery] SessionsByRangeModel model)
        {
            if(model.days == null)
            {
                model.days = 7;
            }

            var descriptor = _mapper.Map<SessionsByRangeDescriptor>(model);
            return await _sessionService.GetSessionsByRange(descriptor);
        }

        [HttpGet("seat/items/{sessionId}")]
        public async Task<IEnumerable<IEnumerable<SessionSeatResponse>>> GetSeatsBySessionId(int sessionId)
        {
            var seats =  await _sessionService.GetSeatsBySessionIdAsync(sessionId);
            return _mapper.Map<IEnumerable<IEnumerable<SessionSeatResponse>>>(seats);
        }

        [HttpPost("seat/changeStasus")]
        public async Task ChangeSeatsStatusAsync(ChangeSessionSeatsStatusModel model)
        {
            var descriptors = _mapper.Map<IEnumerable<ChangeSessionSeatStatusDescriptor>>(model.Seats);
            await _sessionService.ChangeSessionSeatsStatusAsync(model.SessionId, descriptors);
        }
    }
}
