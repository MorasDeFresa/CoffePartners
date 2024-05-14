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

    public class CultivationController : ControllerBase
    {
        private readonly ICultivationService _cultivationService;

        public CultivationController(ICultivationService cultivationService)
        {
            _cultivationService = cultivationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cultivation>>> GetCultivations()
        {
            return Ok(await _cultivationService.getCultivations());
        }

        [HttpGet("{IdCultivation}")]
        public async Task<ActionResult<Cultivation>> GetCultivation(int IdCultivation)
        {
            var clase = await _cultivationService.getCultivation(IdCultivation);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Cultivation>> CreateCultivation(DateTime DateCultivation, float Area, int IdFarm, int IdStateCultivation)
        {
            try
            {
                var createdClass = await _cultivationService.createCultivation(DateCultivation, Area, IdFarm, IdStateCultivation);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear el cultivo");
                }
                return CreatedAtAction(nameof(GetCultivations), new { IdCultivation = createdClass.IdCultivation }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cultivo: {ex.Message}");
            }
        }

        [HttpPut("{IdCultivation}")]
        public async Task<ActionResult<Cultivation>> UpdateCultivation(int IdCultivation, DateTime DateCultivation, float Area, int IdFarm, int IdStateCultivation)
        {
            var updatedClass = await _cultivationService.updateCultivation(IdCultivation, DateCultivation, Area, IdFarm, IdStateCultivation);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdCultivation}")]
        public async Task<ActionResult<Cultivation>> DeleteCultivation(int IdCultivation)
        {
            var deletedClass = await _cultivationService.deleteCultivation(IdCultivation);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}