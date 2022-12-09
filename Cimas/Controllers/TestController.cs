using Cimas.Entities.Companies;
using Cimas.Infrastructure.Extensions;
using Cimas.Models.From;
using Cimas.Service.Halls;
using Cimas.Service.Halls.Descriptors;
using Cimas.Service.Sessions;
using Cimas.Service.Sessions.Descriptors;
using Cimas.Storage.Uow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHallService _hallService;
        private readonly ISessionService _sessionService;
        public TestController(
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor,
            IHallService hallService,
            ISessionService sessionService)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _hallService = hallService;
            _sessionService = sessionService;
        }

        [HttpGet("company/items")]
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _uow.CompanyRepository.FindAllAsync();
        }

        [HttpGet("userlogin"), Authorize]
        public  string GetUserLogin()
        {
            return _httpContextAccessor.HttpContext.User.GetUserName();
        }
        [HttpGet("userrole"), Authorize]
        public string GetUseRole()
        {
            return _httpContextAccessor.HttpContext.User.GetUserRole();
        }

        [HttpPost("addHall")]
        public async Task CreateHall()
        {
            var hall = new AddHallDescriptor()
            {
                CinemaId = 1,
                Name = "Зал №4",
                Rows = 6,
                Coloums = 4
            };

            await _hallService.AddHallAsync(hall);
        }

        [HttpPost("addSession")]
        public async Task CreateSession()
        {
            var session = new AddSessionDescriptor()
            {
                FilmId = 1,
                HallId = 3,
                TicketPrice = 70,
                StartDateTime = System.DateTime.Now
            };

            await _sessionService.AddSessionAsync(session);
        }
    }
}
