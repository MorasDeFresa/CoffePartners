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

    public class ScoreController : Controller
    {
        private readonly IScoreRepository _scoreRepository;
        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Score>))]
        public IActionResult getScores()
        {
            var Scores = _scoreRepository.getScores();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(Scores);
        }
    }
}