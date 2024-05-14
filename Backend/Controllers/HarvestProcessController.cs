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

    public class HarvestProcessController : ControllerBase
    {
        private readonly IHarvestProcessService _cultivationHarvestService;

        public HarvestProcessController(IHarvestProcessService cultivationHarvestService)
        {
            _cultivationHarvestService = cultivationHarvestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HarvestProcess>>> GetHarvestProcesss()
        {
            return Ok(await _cultivationHarvestService.getHarvestProcesss());
        }

        [HttpGet("{IdHarvestProcess}")]
        public async Task<ActionResult<HarvestProcess>> GetHarvestProcess(int IdHarvestProcess)
        {
            var clase = await _cultivationHarvestService.getHarvestProcess(IdHarvestProcess);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<HarvestProcess>> CreateHarvestProcess(int IdCultivationHarvest, int IdTypeProcess, float HeightWastedGrain)
        {
            try
            {
                var createdClass = await _cultivationHarvestService.createHarvestProcess(IdCultivationHarvest, IdTypeProcess, HeightWastedGrain);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la cosecha");
                }
                return CreatedAtAction(nameof(GetHarvestProcess), new { IdHarvestProcess = createdClass.IdHarvestProcess }, createdClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la cosecha: {ex.Message}");
            }
        }

        [HttpPut("{IdHarvestProcess}")]

        public async Task<ActionResult<HarvestProcess>> UpdateHarvestProcess(int IdHarvestProcess, int IdCultivationHarvest, int IdTypeProcess, float HeightWastedGrain)
        {
            var updatedClass = await _cultivationHarvestService.updateHarvestProcess(IdHarvestProcess, IdCultivationHarvest, IdTypeProcess, HeightWastedGrain);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdHarvestProcess}")]
        public async Task<ActionResult<HarvestProcess>> DeleteHarvestProcess(int IdHarvestProcess)
        {
            var deletedClass = await _cultivationHarvestService.deleteHarvestProcess(IdHarvestProcess);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }

    }
}