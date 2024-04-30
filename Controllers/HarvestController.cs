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

    public class HarvestController : ControllerBase
    {
        private readonly IHarvestService _harvestService;

        public HarvestController(IHarvestService harvestService)
        {
            _harvestService = harvestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Harvest>>> GetHarvests()
        {
            return Ok(await _harvestService.getHarvests());
        }

        [HttpGet("{IdHarvest}")]
        public async Task<ActionResult<Harvest>> GetHarvest(int IdHarvest)
        {
            var clase = await _harvestService.getHarvest(IdHarvest);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Harvest>> CreateHarvest(DateTime DateHarvest, int IdTypeQuality)
        {
            try
            {
                var createdClass = await _harvestService.createHarvest(DateHarvest, IdTypeQuality);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la cosecha");
                }
                return CreatedAtAction(nameof(GetHarvest), new { IdHarvest = createdClass.IdHarvest }, createdClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la cosecha: {ex.Message}");
            }
        }

        [HttpPut("{IdHarvest}")]

        public async Task<ActionResult<Harvest>> UpdateHarvest(int IdHarvest, DateTime DateHarvest, int IdTypeQuality)
        {
            var updatedClass = await _harvestService.updateHarvest(IdHarvest, DateHarvest, IdTypeQuality);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdHarvest}")]
        public async Task<ActionResult<Harvest>> DeleteHarvest(int IdHarvest)
        {
            var deletedClass = await _harvestService.deleteHarvest(IdHarvest);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }

    }
}