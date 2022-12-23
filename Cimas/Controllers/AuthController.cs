using AutoMapper;
using Cimas.Infrastructure.Extensions;
using Cimas.Models.Auth;
using Cimas.Service.Authorization;
using Cimas.Service.Authorization.Descriptors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(
            IAuthService authService,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task Registor(RegistrationModel model)
        {
            if (model.CompanyId == null)
            {
                model.CompanyId = _httpContextAccessor.HttpContext.User.GetCompanyId();
            }
            var descriptor = _mapper.Map<RegistrationDescriptor>(model);
            
            await _authService.AddUserAsync(descriptor);
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<string> Login(LoginModel model)
        {
            var descriptor = _mapper.Map<LoginDescriptor>(model);
            var token = await _authService.LoginAndGetTokenAsync(descriptor);

            return token;
        }
    }
}
