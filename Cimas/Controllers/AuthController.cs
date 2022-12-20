using AutoMapper;
using Cimas.Models.Auth;
using Cimas.Service.Authorization;
using Cimas.Service.Authorization.Descriptors;
using Microsoft.AspNetCore.Authorization;
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

        public AuthController(
            IAuthService authService,
            IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task Registor(RegistrationModel model)
        {
            var descriptor = _mapper.Map<RegistrationDescriptor>(model);
            await _authService.AddUserAsync(descriptor);
        }

        [HttpPost("login")]
        public async Task<string> Login(LoginModel model)
        {
            var descriptor = _mapper.Map<LoginDescriptor>(model);
            var token = await _authService.LoginAndGetTokenAsync(descriptor);

            return token;
        }
    }
}
