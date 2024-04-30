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

    public class StatesCultivationController : ControllerBase
    {
        private readonly IStatesCultivationService _statesCultivationService;

        public StatesCultivationController(IStatesCultivationService statesCultivationService)
        {
            _statesCultivationService = statesCultivationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatesCultivation>>> GetStatesCultivations()
        {
            return Ok(await _statesCultivationService.getStatesCultivations());
        }

        [HttpGet("{IdStatesCultivation}")]
        public async Task<ActionResult<StatesCultivation>> GetStatesCultivation(int IdStatesCultivation)
        {
            var clase = await _statesCultivationService.getStatesCultivation(IdStatesCultivation);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<StatesCultivation>> CreateStatesCultivation(string NameStateCultivation)
        {
            try
            {
                var createdClass = await _statesCultivationService.createStatesCultivation(NameStateCultivation);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear el cultivo");
                }
                return CreatedAtAction(nameof(GetStatesCultivations), new { IdStatesCultivation = createdClass.IdStatesCultivation }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cultivo: {ex.Message}");
            }
        }

        [HttpPut("{IdStatesCultivation}")]
        public async Task<ActionResult<StatesCultivation>> UpdateStatesCultivation(int IdStatesCultivation, string NameStateCultivation)
        {
            var updatedClass = await _statesCultivationService.updateStatesCultivation(IdStatesCultivation, NameStateCultivation);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdStatesCultivation}")]
        public async Task<ActionResult<StatesCultivation>> DeleteStatesCultivation(int IdStatesCultivation)
        {
            var deletedClass = await _statesCultivationService.deleteStatesCultivation(IdStatesCultivation);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}