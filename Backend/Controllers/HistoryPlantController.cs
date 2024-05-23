using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class HistoryPlantPost()
    {
        public required DateTime DatePlantProcess { get; set; }
        public required int IdPlant { get; set; }
        public required int IdPlantState { get; set; }
    }

    public class HistoryPlantPut()
    {
        public DateTime? DatePlantProcess { get; set; }
        public int? IdPlant { get; set; }
        public int? IdPlantState { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class HistoryPlantController : ControllerBase
    {
        private readonly IHistoryPlantRepository _HistoryPlantRepository;

        public HistoryPlantController(IHistoryPlantRepository HistoryPlantRepository)
        {
            _HistoryPlantRepository = HistoryPlantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistoryPlant>>> GetHistoryPlants()
        {
            try
            {
                return Ok(await _HistoryPlantRepository.GetHistoryPlants());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdHistoryPlant}")]
        public async Task<ActionResult<HistoryPlant>> GetHistoryPlant(int IdHistoryPlant)
        {
            try
            {
                var HistoryPlant = await _HistoryPlantRepository.GetHistoryPlant(IdHistoryPlant);
                if (HistoryPlant == null)
                {
                    return NotFound("HistoryPlant not found");
                }
                return Ok(HistoryPlant);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<HistoryPlant>> CreateHistoryPlant(HistoryPlantPost HistoryPlantPost)
        {
            try
            {
                var HistoryPlant = new HistoryPlant
                {
                    DatePlantProcess = HistoryPlantPost.DatePlantProcess,
                    IdPlant = HistoryPlantPost.IdPlant,
                    IdPlantState = HistoryPlantPost.IdPlantState
                };

                var createdHistoryPlant = await _HistoryPlantRepository.CreateHistoryPlant(HistoryPlant);
                if (createdHistoryPlant == null)
                {
                    return BadRequest("create HistoryPlant");
                }
                return CreatedAtAction(nameof(GetHistoryPlants), new { IdHistoryPlant = createdHistoryPlant.IdHistoryPlant }, createdHistoryPlant);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdHistoryPlant}")]
        public async Task<ActionResult<HistoryPlant>> UpdateHistoryPlant(int IdHistoryPlant, HistoryPlantPut HistoryPlantPut)
        {
            try
            {
                var HistoryPlant = await _HistoryPlantRepository.GetHistoryPlant(IdHistoryPlant);
                if (HistoryPlant == null) return BadRequest("update HistoryPlant");
                if (HistoryPlantPut.IdPlant != null) HistoryPlant.IdPlant = (int)HistoryPlantPut.IdPlant;
                if (HistoryPlantPut.DatePlantProcess != null) HistoryPlant.DatePlantProcess = (DateTime)HistoryPlantPut.DatePlantProcess;
                if (HistoryPlantPut.IdPlantState != null) HistoryPlant.IdPlantState = (int)HistoryPlantPut.IdPlantState;

                var updatedHistoryPlant = await _HistoryPlantRepository.UpdateHistoryPlant(HistoryPlant);
                if (updatedHistoryPlant == null)
                {
                    return NotFound();
                }
                return Ok(updatedHistoryPlant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdHistoryPlant}")]
        public async Task<ActionResult<HistoryPlant>> DeleteHistoryPlant(int IdHistoryPlant)
        {
            try
            {
                var deletedHistoryPlant = await _HistoryPlantRepository.DeleteHistoryPlant(IdHistoryPlant);
                if (deletedHistoryPlant == false)
                {
                    return NotFound();
                }
                return Ok(deletedHistoryPlant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}