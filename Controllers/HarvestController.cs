using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoffePartners.Controllers
{
  [Route("api/[controller]")]
    [ApiController]

    public class HarvestController : Controller
    {
        private readonly IHarvestRepository _harvestRepository;
        public HarvestController(IHarvestRepository harvestRepository)
        {
            _harvestRepository = harvestRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Harvest>))]
        public IActionResult getHarvests()
        {
            var farms = _harvestRepository.getHarvests();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(farms);
        }
    }  
}