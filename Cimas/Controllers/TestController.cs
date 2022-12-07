using Cimas.Entities.Companies;
using Cimas.Infrastructure.Extensions;
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
        public readonly IHttpContextAccessor _httpContextAccessor;
        public TestController(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("company/items")]
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _uow.Companies.FindAllAsync();
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
    }
}
