﻿using AutoMapper;
using Cimas.Infrastructure.Extensions;
using Cimas.Models.From;
using Cimas.Models.To;
using Cimas.Service.Cinemas;
using Cimas.Service.Cinemas.Descriptors;
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
    public class CinemaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICinemaService _cinemaService;

        public CinemaController(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ICinemaService cinemaService)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _cinemaService = cinemaService;
        }

        [HttpPost("add"), Authorize(Roles = "CompanyAdmin")]
        public async Task<int> AddCinema(AddCinemaModel model)
        {
            var descriptor = _mapper.Map<AddCinemaDescriptor>(model);
            descriptor.CompanyId = _httpContextAccessor.HttpContext.User.GetCompanyId();

            return await _cinemaService.AddCinemaAsync(descriptor);
        }

        [HttpDelete("del/{cinemaId}"), Authorize(Roles = "CompanyAdmin")]
        public async Task DeleteCinema(int cinemaId)
        {
            await _cinemaService.DeleteCinemaAsync(cinemaId);
        }

        [HttpGet("items")]
        public async Task<IEnumerable<CinemasResponse>> GetCinemasByComnapyId()
        {
            var companyId = _httpContextAccessor.HttpContext.User.GetCompanyId();
            var cinemas = await _cinemaService.GetCinemasByComnapyIdAsync(companyId);

            return _mapper.Map<IEnumerable<CinemasResponse>>(cinemas);
        }
    }
}
