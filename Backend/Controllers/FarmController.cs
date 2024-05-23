using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class FarmPost()
    {
        public required string NameFarm { get; set; }
        public required float Latitude { get; set; }
        public required float Longitude { get; set; }
        public required int IdFarmer { get; set; }
    }

    public class FarmPut()
    {
        public string? NameFarm { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int? IdFarmer { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class FarmController : ControllerBase
    {
        private readonly IFarmRepository _FarmRepository;

        public FarmController(IFarmRepository FarmRepository)
        {
            _FarmRepository = FarmRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Farm>>> GetFarms()
        {
            try
            {
                return Ok(await _FarmRepository.GetFarms());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdFarm}")]
        public async Task<ActionResult<Farm>> GetFarm(int IdFarm)
        {
            try
            {
                var Farm = await _FarmRepository.GetFarm(IdFarm);
                if (Farm == null)
                {
                    return NotFound("Farm not found");
                }
                return Ok(Farm);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Farm>> CreateFarm(FarmPost FarmPost)
        {
            try
            {
                var Farm = new Farm
                {
                    CreateDateFarm = DateTime.Now,
                    UpdateDateFarm = DateTime.Now,
                    IdFarmer = FarmPost.IdFarmer,
                    NameFarm = FarmPost.NameFarm,
                    Latitude = FarmPost.Latitude,
                    Longitude = FarmPost.Longitude,
                };

                var createdFarm = await _FarmRepository.CreateFarm(Farm);
                if (createdFarm == null)
                {
                    return BadRequest("create Farm");
                }
                return CreatedAtAction(nameof(GetFarms), new { IdFarm = createdFarm.IdFarm }, createdFarm);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdFarm}")]
        public async Task<ActionResult<Farm>> UpdateFarm(int IdFarm, FarmPut FarmPut)
        {
            try
            {
                var Farm = await _FarmRepository.GetFarm(IdFarm);
                if (Farm == null) return BadRequest("update Farm");
                if (FarmPut.NameFarm != null) Farm.NameFarm = FarmPut.NameFarm;
                if (FarmPut.IdFarmer != null) Farm.IdFarmer = (int)FarmPut.IdFarmer;
                if (FarmPut.Latitude != null) Farm.Latitude = (float)FarmPut.Latitude;
                if (FarmPut.Longitude != null) Farm.Longitude = (float)FarmPut.Longitude;
                Farm.UpdateDateFarm = DateTime.Now;
                var updatedFarm = await _FarmRepository.UpdateFarm(Farm);
                if (updatedFarm == null)
                {
                    return NotFound();
                }
                return Ok(updatedFarm);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdFarm}")]
        public async Task<ActionResult<Farm>> DeleteFarm(int IdFarm)
        {
            try
            {
                var deletedFarm = await _FarmRepository.DeleteFarm(IdFarm);
                if (deletedFarm == false)
                {
                    return NotFound();
                }
                return Ok(deletedFarm);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}