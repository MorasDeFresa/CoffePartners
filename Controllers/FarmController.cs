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

    public class FarmController : Controller
    {
        private readonly IFarmRepository _farmRepository;
        public FarmController(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Farm>))]
        public IActionResult getFarms()
        {
            var farms = _farmRepository.getFarms();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(farms);
        }
    }
}