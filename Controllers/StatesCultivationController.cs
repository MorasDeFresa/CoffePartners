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

    public class StatesCultivationController : Controller
    {
        private readonly IStatesCultivationRepository _statesCultivationRepository;
        public StatesCultivationController(IStatesCultivationRepository statesCultivationRepository)
        {
            _statesCultivationRepository = statesCultivationRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StatesCultivation>))]
        public IActionResult getStatesCultivations()
        {
            var statesCultivations = _statesCultivationRepository.getStatesCultivations();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(statesCultivations);
        }
    }
}