using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoffePartners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HarvestProcessController : Controller
    {
        private readonly IHarvestProcessRepository _harvestProcessRepository;
        public HarvestProcessController(IHarvestProcessRepository harvestProcessRepository)
        {
            _harvestProcessRepository = harvestProcessRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HarvestRepository>))]
        public IActionResult getHarvestProcess()
        {
            var farms = _harvestProcessRepository.getHarvestProcesss();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(farms);
        }
    }
}