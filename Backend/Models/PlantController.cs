using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class PlantPost()
    {
        public required float PositionX { get; set; }
        public required float PositionZ { get; set; }
        public required int IdFarm { get; set; }
    }

    public class PlantPut()
    {
        public float? PositionX { get; set; }
        public float? PositionZ { get; set; }
        public int? IdFarm { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class PlantController : ControllerBase
    {
        private readonly IPlantRepository _PlantRepository;

        public PlantController(IPlantRepository PlantRepository)
        {
            _PlantRepository = PlantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Plant>>> GetPlants()
        {
            try
            {
                return Ok(await _PlantRepository.GetPlants());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdPlant}")]
        public async Task<ActionResult<Plant>> GetPlant(int IdPlant)
        {
            try
            {
                var Plant = await _PlantRepository.GetPlant(IdPlant);
                if (Plant == null)
                {
                    return NotFound("Plant not found");
                }
                return Ok(Plant);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Plant>> CreatePlant(PlantPost PlantPost)
        {
            try
            {
                var Plant = new Plant
                {
                    PositionX = PlantPost.PositionX,
                    PositionZ = PlantPost.PositionZ,
                    IdFarm = PlantPost.IdFarm
                };

                var createdPlant = await _PlantRepository.CreatePlant(Plant);
                if (createdPlant == null)
                {
                    return BadRequest("create Plant");
                }
                return CreatedAtAction(nameof(GetPlants), new { IdPlant = createdPlant.IdPlant }, createdPlant);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdPlant}")]
        public async Task<ActionResult<Plant>> UpdatePlant(int IdPlant, PlantPut PlantPut)
        {
            try
            {
                var Plant = await _PlantRepository.GetPlant(IdPlant);
                if (Plant == null) return BadRequest("update Plant");
                if (PlantPut.PositionX != null) Plant.PositionX = (float)PlantPut.PositionX;
                if (PlantPut.PositionZ != null) Plant.PositionZ = (float)PlantPut.PositionZ;
                if (PlantPut.IdFarm != null) Plant.IdFarm = (int)PlantPut.IdFarm;

                var updatedPlant = await _PlantRepository.UpdatePlant(Plant);
                if (updatedPlant == null)
                {
                    return NotFound();
                }
                return Ok(updatedPlant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdPlant}")]
        public async Task<ActionResult<Plant>> DeletePlant(int IdPlant)
        {
            try
            {
                var deletedPlant = await _PlantRepository.DeletePlant(IdPlant);
                if (deletedPlant == false)
                {
                    return NotFound();
                }
                return Ok(deletedPlant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}