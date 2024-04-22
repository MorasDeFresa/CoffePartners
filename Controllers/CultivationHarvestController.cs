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

    public class CultivationHarvestController :Controller
    {
        private readonly ICultivationHarvestRepository _cultivationHarvestRepository;

        public CultivationHarvestController(ICultivationHarvestRepository cultivationHarvestRepository)
        {
            _cultivationHarvestRepository = cultivationHarvestRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CultivationHarvest>))]
        public IActionResult getCultivationHarvests()
        {
            var cultivationHarvests = _cultivationHarvestRepository.getCultivationHarvests();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(cultivationHarvests);
        }
    }
}