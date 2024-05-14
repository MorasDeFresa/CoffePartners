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

    public class FarmController : ControllerBase
    {
        private readonly IFarmService _farmService;

        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Farm>>> GetFarms()
        {
            return Ok(await _farmService.getFarms());
        }

        [HttpGet("{IdFarm}")]
        public async Task<ActionResult<Farm>> GetFarm(int IdFarm)
        {
            var clase = await _farmService.getFarm(IdFarm);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Farm>> CreateFarm(string NameFarm, int IdPlayer, float SizeFarm)
        {
            try
            {
                var createdClass = await _farmService.createFarm(NameFarm, IdPlayer, SizeFarm);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear la cosecha");
                }
                return CreatedAtAction(nameof(GetFarm), new { IdFarm = createdClass.IdFarm }, createdClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la cosecha: {ex.Message}");
            }
        }

        [HttpPut("{IdFarm}")]

        public async Task<ActionResult<Farm>> UpdateFarm(int IdFarm, string NameFarm, int IdPlayer, float SizeFarm)
        {
            var updatedClass = await _farmService.updateFarm(IdFarm, NameFarm, IdPlayer, SizeFarm);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdFarm}")]
        public async Task<ActionResult<Farm>> DeleteFarm(int IdFarm)
        {
            var deletedClass = await _farmService.deleteFarm(IdFarm);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }

    }
}