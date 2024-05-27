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

    public class PlantStatesController : ControllerBase
    {
        private readonly IPlantStatesRepository _PlantStatesRepository;

        public PlantStatesController(IPlantStatesRepository PlantStatesRepository)
        {
            _PlantStatesRepository = PlantStatesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlantStates>>> GetPlantStatess()
        {
            return Ok(await _PlantStatesRepository.GetPlantStatess());
        }

        [HttpGet("{IdPlantStates}")]
        public async Task<ActionResult<PlantStates>> GetPlantStates(int IdPlantStates)
        {
            var clase = await _PlantStatesRepository.GetPlantStates(IdPlantStates);
            if (clase == null)
            {
                return NotFound("PlantStates no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<PlantStates>> CreatePlantStates(PlantStates PlantStates)
        {
            try
            {
                var createdClass = await _PlantStatesRepository.CreatePlantStates(PlantStates);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear PlantStates");
                }
                return CreatedAtAction(nameof(GetPlantStatess), new { IdPlantStates = createdClass.IdPlantState }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear PlantStates: {ex.Message}");
            }
        }

        [HttpPut("{IdPlantStates}")]
        public async Task<ActionResult<PlantStates>> UpdatePlantStates(PlantStates PlantStates)
        {
            var updatedClass = await _PlantStatesRepository.UpdatePlantStates(PlantStates);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdPlantStates}")]
        public async Task<ActionResult<PlantStates>> DeletePlantStates(int IdPlantStates)
        {
            var deletedClass = await _PlantStatesRepository.DeletePlantStates(IdPlantStates);
            if (deletedClass == false)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}