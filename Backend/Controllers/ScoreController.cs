using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;




namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _ScoreRepository;

        public ScoreController(IScoreRepository ScoreRepository)
        {
            _ScoreRepository = ScoreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Score>>> GetScores()
        {
            return Ok(await _ScoreRepository.GetScores());
        }

        [HttpGet("{IdScore}")]
        public async Task<ActionResult<Score>> GetScore(int IdScore)
        {
            var clase = await _ScoreRepository.GetScore(IdScore);
            if (clase == null)
            {
                return NotFound("Score no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Score>> CreateScore(Score Score)
        {
            try
            {
                var createdClass = await _ScoreRepository.CreateScore(Score);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear Score");
                }
                return CreatedAtAction(nameof(GetScores), new { IdScore = createdClass.IdScore }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Score: {ex.Message}");
            }
        }

        [HttpPut("{IdScore}")]
        public async Task<ActionResult<Score>> UpdateScore(Score Score)
        {
            var updatedClass = await _ScoreRepository.UpdateScore(Score);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdScore}")]
        public async Task<ActionResult<Score>> DeleteScore(int IdScore)
        {
            var deletedClass = await _ScoreRepository.DeleteScore(IdScore);
            if (deletedClass == false)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}