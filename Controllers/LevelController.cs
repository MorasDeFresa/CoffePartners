using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;
using CoffePartners.Services;
using Microsoft.AspNetCore.Mvc;




namespace CoffePartners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Level>>> GetLevels()
        {
            return Ok(await _levelService.getLevels());
        }

        [HttpGet("{IdLevel}")]
        public async Task<ActionResult<Level>> GetLevel(int IdLevel)
        {
            var clase = await _levelService.getLevel(IdLevel);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Level>> CreateLevel(float Duration, string Description)
        {
            try
            {
                var createdClass = await _levelService.createLevel(Duration, Description);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear el cultivo");
                }
                return CreatedAtAction(nameof(GetLevels), new { IdLevel = createdClass.IdLevel }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cultivo: {ex.Message}");
            }
        }

        [HttpPut("{IdLevel}")]
        public async Task<ActionResult<Level>> UpdateLevel(int IdLevel, float Duration, string Description)
        {
            var updatedClass = await _levelService.updateLevel(IdLevel, Duration, Description);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdLevel}")]
        public async Task<ActionResult<Level>> DeleteLevel(int IdLevel)
        {
            var deletedClass = await _levelService.deleteLevel(IdLevel);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}