using AutoMapper;
using Cimas.Entities.WorkDays;
using Cimas.Infrastructure.Extensions;
using Cimas.Models.From;
using Cimas.Service.WorkDays;
using Cimas.Service.WorkDays.Descriptors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WorkDayController : ControllerBase
    {
        private readonly IWorkDayService _workDayService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkDayController(
            IWorkDayService workDayService,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _workDayService = workDayService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("start")]
        public async Task<int> StartWorkDay(StartWorkDayModel model)
        {
            var descriptor = _mapper.Map<StartWorkDayDescriptor>(model);
            descriptor.UserId = _httpContextAccessor.HttpContext.User.GetUserId();

            return await _workDayService.StartWorkDayAsync(descriptor);
        }

        [HttpGet("userHaveNotFinished")]
        public async Task<bool> UserHasStartedWorkDay()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            return await _workDayService.UserHasNotFinishedWorkDayAsync(userId);
        }

        [HttpGet("current")]
        public async Task<WorkDay> GetCurrentWorkDay()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            return await _workDayService.GetNotFinishedWorkDayOfUserAsync(userId);
        }

        [HttpPost("end")]
        public async Task EndWorkDay(int workDayId)
        {
            await _workDayService.EndWorkDayAsync(workDayId);
        }
    }
}
