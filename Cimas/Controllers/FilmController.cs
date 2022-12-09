using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cimas.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IMapper _mapper;
        public FilmController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
