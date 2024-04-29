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

    public class CultivationHarvestController : ControllerBase
    {
        private readonly ICultivationHarvestService _cultivationHarvestService;

        public CultivationHarvestController(ICultivationHarvestService cultivationHarvestService)
        {
            _cultivationHarvestService = cultivationHarvestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CultivationHarvest>>> GetCultivationHarvests()
        {
            return Ok(await _cultivationHarvestService.getCultivationHarvests());
        }

        [HttpGet("{IdCultivationHarvest}")]
        public async Task<ActionResult<CultivationHarvest>> GetCultivationHarvest(int IdCultivationHarvest)
        {
            var clase = await _cultivationHarvestService.getCultivationHarvest(IdCultivationHarvest);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<CultivationHarvest>> CreateCultivationHarvest(Cultivation IdCultivation, Harvest IdHarvest, float WeightHarvest)
        {
            try
            {
                var createdClass = await _cultivationHarvestService.createCultivationHarvest(IdCultivation, IdHarvest, WeightHarvest);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la cosecha");
                }
                return CreatedAtAction(nameof(GetCultivationHarvest), new { IdCultivationHarvest = createdClass.IdCultivationHarvest }, createdClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la cosecha: {ex.Message}");
            }
        }

        [HttpPut("{IdCultivationHarvest}")]

        public async Task<ActionResult<CultivationHarvest>> UpdateCultivationHarvest(int IdCultivationHarvest, Cultivation IdCultivation, Harvest IdHarvest, float WeightHarvest)
        {
            var updatedClass = await _cultivationHarvestService.updateCultivationHarvest(IdCultivationHarvest, IdCultivation, IdHarvest, WeightHarvest);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdCultivationHarvest}")]
        public async Task<ActionResult<CultivationHarvest>> DeleteCultivationHarvest(int IdCultivationHarvest)
        {
            var deletedClass = await _cultivationHarvestService.deleteCultivationHarvest(IdCultivationHarvest);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }

    }
}