using AutoMapper;
using Cimas.Entities.WorkDays;
using Cimas.Infrastructure.Extensions;
using Cimas.Models.From;
using Cimas.Models.To;
using Cimas.Service.WorkDays;
using Cimas.Service.WorkDays.Descriptors;
using Cimas.Storage.Repositories.Reports.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpPost("start"), Authorize(Roles = "Worker")]
        public async Task<int> StartWorkDay(StartWorkDayModel model)
        {
            var descriptor = _mapper.Map<StartWorkDayDescriptor>(model);
            descriptor.UserId = _httpContextAccessor.HttpContext.User.GetUserId();

            return await _workDayService.StartWorkDayAsync(descriptor);
        }

        [HttpGet("userHaveNotFinished"), Authorize(Roles = "Worker")]
        public async Task<bool> UserHasStartedWorkDay()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            return await _workDayService.UserHasNotFinishedWorkDayAsync(userId);
        }

        [HttpGet("current"), Authorize(Roles = "Worker")]
        public async Task<WorkDayReponse> GetCurrentWorkDay()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var workday = await _workDayService.GetNotFinishedWorkDayOfUserAsync(userId);

            return _mapper.Map<WorkDayReponse>(workday);
        }

        [HttpPost("end"), Authorize(Roles = "Worker")]
        public async Task EndWorkDay(int workDayId)
        {
            await _workDayService.EndWorkDayAsync(workDayId);
        }

        [HttpGet("report/items"), Authorize(Roles = "Reviewer")]
        public async Task<IEnumerable<FullReportView>> GetReportsListByCompanyId()
        {
            var companyId = _httpContextAccessor.HttpContext.User.GetCompanyId();
            return await _workDayService.GetReportsListByCompanyIdAsync(companyId);
        }

        [HttpPut("report/setStatus"), Authorize(Roles = "Reviewer")]
        public async Task SetReportStatus(EditReportModel model)
        {
            //TODO: implement йопта!
        }
    }
}
