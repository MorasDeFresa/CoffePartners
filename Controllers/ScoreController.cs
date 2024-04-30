using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;
using CoffePartners.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CoffePartners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Score>>> GetScores()
        {
            return Ok(await _scoreService.getScores());
        }

        [HttpGet("{IdScore}")]
        public async Task<ActionResult<Score>> GetScore(int IdScore)
        {
            var clase = await _scoreService.getScore(IdScore);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Score>> CreateScore(float Points, int IdLevel, int IdFarm)
        {
            try
            {
                var createdClass = await _scoreService.createScore(Points, IdLevel, IdFarm);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la cosecha");
                }
                return CreatedAtAction(nameof(GetScore), new { IdScore = createdClass.IdScore }, createdClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la cosecha: {ex.Message}");
            }
        }

        [HttpPut("{IdScore}")]

        public async Task<ActionResult<Score>> UpdateScore(int IdScore, float Points, int IdLevel, int IdFarm)
        {
            var updatedClass = await _scoreService.updateScore(IdScore, Points, IdLevel, IdFarm);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdScore}")]
        public async Task<ActionResult<Score>> DeleteScore(int IdScore)
        {
            var deletedClass = await _scoreService.deleteScore(IdScore);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }

    }
}