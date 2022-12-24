using AutoMapper;
using Cimas.Entities.Films;
using Cimas.Infrastructure.Extensions;
using Cimas.Models.From;
using Cimas.Models.To;
using Cimas.Service.Films;
using Cimas.Service.Films.Descriptors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Authorize(Roles = "CompanyAdmin")]
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFilmService _filmService;

        public FilmController(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IFilmService filmService)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _filmService = filmService;
        }

        [HttpPost("add")]
        public async Task<int> AddFilm(AddFilmModel model)
        {
            var descriptor = _mapper.Map<AddFilmDescriptor>(model);
            descriptor.CompanyId = _httpContextAccessor.HttpContext.User.GetCompanyId();

            return await _filmService.AddFilmAsync(descriptor);
        }

        [HttpDelete("del/{filmId}")]
        public async Task DeleteFilm(int filmId)
        {
            await _filmService.DeleteFilmAsync(filmId);
        }

        [HttpGet("items")]
        public async Task<IEnumerable<FilmResponse>> GetFilmsByComnapyId()
        {
            var companyId = _httpContextAccessor.HttpContext.User.GetCompanyId();
            var film =  await _filmService.GetFilmsByComnapyIdAsync(companyId);

            return _mapper.Map<IEnumerable<FilmResponse>>(film);
        }
    }
}
