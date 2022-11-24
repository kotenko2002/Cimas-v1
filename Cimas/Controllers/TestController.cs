using Cimas.Entities.Areas;
using Cimas.Entities.Companies;
using Cimas.Storage.Uow;
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

        public TestController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("company/items")]
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _uow.Companies.FindAllAsync();
        }
        [HttpGet("area/items")]
        public async Task<IEnumerable<Area>> GetAllAreas()
        {
            return await _uow.Areas.FindAllAsync();
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
