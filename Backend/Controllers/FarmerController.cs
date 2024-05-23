using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class FarmerPost()
    {
        public required string NickNameFarmer { get; set; }
        public required int IdUser { get; set; }
    }

    public class FarmerPut()
    {
        public string? NickNameFarmer { get; set; }
        public int? IdUser { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class FarmerController : ControllerBase
    {
        private readonly IFarmerRepository _FarmerRepository;

        public FarmerController(IFarmerRepository FarmerRepository)
        {
            _FarmerRepository = FarmerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Farmer>>> GetFarmers()
        {
            try
            {
                return Ok(await _FarmerRepository.GetFarmers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdFarmer}")]
        public async Task<ActionResult<Farmer>> GetFarmer(int IdFarmer)
        {
            try
            {
                var Farmer = await _FarmerRepository.GetFarmer(IdFarmer);
                if (Farmer == null)
                {
                    return NotFound("Farmer not found");
                }
                return Ok(Farmer);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Farmer>> CreateFarmer(FarmerPost FarmerPost)
        {
            try
            {
                var Farmer = new Farmer
                {
                    NickNameFarmer = FarmerPost.NickNameFarmer,
                    IdUser = FarmerPost.IdUser
                };

                var createdFarmer = await _FarmerRepository.CreateFarmer(Farmer);
                if (createdFarmer == null)
                {
                    return BadRequest("create Farmer");
                }
                return CreatedAtAction(nameof(GetFarmers), new { IdFarmer = createdFarmer.IdFarmer }, createdFarmer);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdFarmer}")]
        public async Task<ActionResult<Farmer>> UpdateFarmer(int IdFarmer, FarmerPut FarmerPut)
        {
            try
            {
                var Farmer = await _FarmerRepository.GetFarmer(IdFarmer);
                if (Farmer == null) return BadRequest("update Farmer");
                if (FarmerPut.NickNameFarmer != null) Farmer.NickNameFarmer = FarmerPut.NickNameFarmer;
                if (FarmerPut.IdUser != null) Farmer.IdUser = (int)FarmerPut.IdUser;

                var updatedFarmer = await _FarmerRepository.UpdateFarmer(Farmer);
                if (updatedFarmer == null)
                {
                    return NotFound();
                }
                return Ok(updatedFarmer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdFarmer}")]
        public async Task<ActionResult<Farmer>> DeleteFarmer(int IdFarmer)
        {
            try
            {
                var deletedFarmer = await _FarmerRepository.DeleteFarmer(IdFarmer);
                if (deletedFarmer == false)
                {
                    return NotFound();
                }
                return Ok(deletedFarmer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}