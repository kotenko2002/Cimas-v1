using AutoMapper;
using Cimas.Infrastructure.Extensions;
using Cimas.Models.To;
using Cimas.Service.Users;
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
    public class UserController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public UserController(
            IHttpContextAccessor httpContextAccessor,
            IUserService userService,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("info")]
        public async Task<GetUserResponse> GetUserInfo()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _userService.GetUserInfoAsync(userId);

            return _mapper.Map<GetUserResponse>(user);
        }

        [HttpGet("items"), Authorize(Roles = "CompanyAdmin")]
        public async Task<IEnumerable<GetUserResponse>> GetUsersByCompanyId()
        {
            var comapnyId = _httpContextAccessor.HttpContext.User.GetCompanyId();
            var users = await _userService.GetUsersByCompanyId(comapnyId);

            return _mapper.Map<IEnumerable<GetUserResponse>>(users);
        }

        [HttpPut("fire/{userId}"), Authorize(Roles = "CompanyAdmin")]
        public async Task FireUser(int userId)
        {
            await _userService.FireUserAsync(userId);
        }
    }
}
