using AutoMapper;
using Cimas.Models.Auth;
using Cimas.Service.Authorization;
using Cimas.Service.Authorization.Descriptors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            if (!ModelState.IsValid)
            {
                //return BadRequest("Modal is not valid.");
                throw new Exception("Modal is not valid.");
            }

            var descriptor = _mapper.Map<RegistrationDescriptor>(model);

            await _authService.AddUserAsync(descriptor);
        }

        //[HttpPost("login")]
        //public async Task<ActionResult<string>> Login(UserDto model)
        //{
        //    var user = _authApiContext.Users.FirstOrDefault(item => item.Username == model.Username);
        //    if (user == null)
        //    {
        //        return BadRequest("User not found.");
        //    }

        //    if (!VerifyPasswordHash(model.Password,
        //            JsonConvert.DeserializeObject<byte[]>(user.PasswordHash),
        //            JsonConvert.DeserializeObject<byte[]>(user.PasswordSalt)))
        //    {
        //        return BadRequest("Wrong password.");
        //    }

        //    string token = CreateToken(user);

        //    return Ok(token);
        //}
    }
}
