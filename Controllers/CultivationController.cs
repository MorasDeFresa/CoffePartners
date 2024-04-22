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

    public class CultivationController : Controller
    {
        private readonly ICultivationRepository _cultivationRepository;

        public CultivationController(ICultivationRepository cultivationRepository)
        {
            _cultivationRepository = cultivationRepository;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cultivation>))]

        public IActionResult getCultivations()
        {
            var cultivations = _cultivationRepository.getCultivations();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(cultivations);
        }
    }
}