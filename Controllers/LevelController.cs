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

    public class LevelController : Controller
    {
        private readonly ILevelRepository _levelRepository;
        public LevelController(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Level>))]
        public IActionResult getLevels()
        {
            var Levels = _levelRepository.getLevels();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(Levels);
        }
    }
}