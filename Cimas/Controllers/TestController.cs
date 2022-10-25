﻿using Cimas.Entities.Areas;
using Cimas.Entities.Companies;
using Cimas.Storage.Uow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IUnitOfWork _uow;

        public TestController(ILogger<TestController> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        [HttpGet("items")]
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _uow.Companies.FindAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Area>> CreateArea(Area area)
        {
            if (ModelState.IsValid)
            {
                _uow.Areas.Add(area);
                await _uow.CompleteAsync();

                return area;
            }

            return BadRequest();
        }
    }
}