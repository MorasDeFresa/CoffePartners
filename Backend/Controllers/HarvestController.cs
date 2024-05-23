using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class HarvestPost()
    {
        public required float WeightHarvest { get; set; }
        public required int IdPlant { get; set; }
        public required int IdTypeQuality { get; set; }
    }

    public class HarvestPut()
    {
        public float? WeightHarvest { get; set; }
        public int? IdPlant { get; set; }
        public int? IdTypeQuality { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class HarvestController : ControllerBase
    {
        private readonly IHarvestRepository _HarvestRepository;

        public HarvestController(IHarvestRepository HarvestRepository)
        {
            _HarvestRepository = HarvestRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Harvest>>> GetHarvests()
        {
            try
            {
                return Ok(await _HarvestRepository.GetGroupHarvests());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdHarvest}")]
        public async Task<ActionResult<Harvest>> GetHarvest(int IdHarvest)
        {
            try
            {
                var Harvest = await _HarvestRepository.GetHarvest(IdHarvest);
                if (Harvest == null)
                {
                    return NotFound("Harvest not found");
                }
                return Ok(Harvest);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("details/plant/{IdPlant}")]
        public async Task<ActionResult<Harvest>> GetDetailsHarvest(int IdPlant)
        {
            try
            {
                var Harvest = await _HarvestRepository.GetDetailHarvests(IdPlant);
                if (Harvest == null)
                {
                    return NotFound("Harvest not found");
                }
                return Ok(Harvest);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Harvest>> CreateHarvest(HarvestPost HarvestPost)
        {
            try
            {
                var Harvest = new Harvest
                {
                    WeightHarvest = HarvestPost.WeightHarvest,
                    IdPlant = HarvestPost.IdPlant,
                    IdTypeQuality = HarvestPost.IdTypeQuality,
                    DateBasketProcess = DateTime.Now
                };

                var createdHarvest = await _HarvestRepository.CreateHarvest(Harvest);
                if (createdHarvest == null)
                {
                    return BadRequest("create Harvest");
                }
                return CreatedAtAction(nameof(GetHarvests), new { IdHarvest = createdHarvest.IdHarvest }, createdHarvest);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdHarvest}")]
        public async Task<ActionResult<Harvest>> UpdateHarvest(int IdHarvest, HarvestPut HarvestPut)
        {
            try
            {
                var Harvest = await _HarvestRepository.GetHarvest(IdHarvest);
                if (Harvest == null) return BadRequest("update Harvest");
                if (HarvestPut.WeightHarvest != null) Harvest.WeightHarvest = (float)HarvestPut.WeightHarvest;
                if (HarvestPut.IdPlant != null) Harvest.IdPlant = (int)HarvestPut.IdPlant;
                if (HarvestPut.IdTypeQuality != null) Harvest.IdTypeQuality = (int)HarvestPut.IdTypeQuality;
                Harvest.DateBasketProcess = DateTime.Now;
                var updatedHarvest = await _HarvestRepository.UpdateHarvest(Harvest);
                if (updatedHarvest == null)
                {
                    return NotFound();
                }
                return Ok(updatedHarvest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdHarvest}")]
        public async Task<ActionResult<Harvest>> DeleteHarvest(int IdHarvest)
        {
            try
            {
                var deletedHarvest = await _HarvestRepository.DeleteHarvest(IdHarvest);
                if (deletedHarvest == false)
                {
                    return NotFound();
                }
                return Ok(deletedHarvest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}