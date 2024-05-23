using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class FarmerArchivementsPost()
    {
        public required int IdArchivement { get; set; }
        public required int IdFarmer { get; set; }
    }

    public class FarmerArchivementsPut()
    {
        public int? IdArchivement { get; set; }
        public int? IdFarmer { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class FarmerArchivementsController : ControllerBase
    {
        private readonly IFarmerArchivementsRepository _FarmerArchivementsRepository;

        public FarmerArchivementsController(IFarmerArchivementsRepository FarmerArchivementsRepository)
        {
            _FarmerArchivementsRepository = FarmerArchivementsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<FarmerArchivements>>> GetFarmerArchivements()
        {
            try
            {
                return Ok(await _FarmerArchivementsRepository.GetFarmerArchivements());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdFarmerArchivements}")]
        public async Task<ActionResult<FarmerArchivements>> GetFarmerArchivements(int IdFarmerArchivements)
        {
            try
            {
                var FarmerArchivements = await _FarmerArchivementsRepository.GetFarmerArchivements(IdFarmerArchivements);
                if (FarmerArchivements == null)
                {
                    return NotFound("FarmerArchivements not found");
                }
                return Ok(FarmerArchivements);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<FarmerArchivements>> CreateFarmerArchivements(FarmerArchivementsPost FarmerArchivementsPost)
        {
            try
            {
                var FarmerArchivements = new FarmerArchivements
                {
                    DateArchivement = DateTime.Now,
                    IdArchivement = FarmerArchivementsPost.IdArchivement,
                    IdFarmer = FarmerArchivementsPost.IdFarmer
                };

                var createdFarmerArchivements = await _FarmerArchivementsRepository.CreateFarmerArchivements(FarmerArchivements);
                if (createdFarmerArchivements == null)
                {
                    return BadRequest("create FarmerArchivements");
                }
                return CreatedAtAction(nameof(GetFarmerArchivements), new { IdFarmerArchivements = createdFarmerArchivements.IdFarmerArchivement }, createdFarmerArchivements);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdFarmerArchivements}")]
        public async Task<ActionResult<FarmerArchivements>> UpdateFarmerArchivements(int IdFarmerArchivements, FarmerArchivementsPut FarmerArchivementsPut)
        {
            try
            {
                var FarmerArchivements = await _FarmerArchivementsRepository.GetFarmerArchivements(IdFarmerArchivements);
                if (FarmerArchivements == null) return BadRequest("update FarmerArchivements");
                if (FarmerArchivementsPut.IdFarmer != null) FarmerArchivements.IdFarmer = (int)FarmerArchivementsPut.IdFarmer;
                if (FarmerArchivementsPut.IdArchivement != null) FarmerArchivements.IdArchivement = (int)FarmerArchivementsPut.IdArchivement;
                FarmerArchivements.DateArchivement = DateTime.Now;
                var updatedFarmerArchivements = await _FarmerArchivementsRepository.UpdateFarmerArchivements(FarmerArchivements);
                if (updatedFarmerArchivements == null)
                {
                    return NotFound();
                }
                return Ok(updatedFarmerArchivements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdFarmerArchivements}")]
        public async Task<ActionResult<FarmerArchivements>> DeleteFarmerArchivements(int IdFarmerArchivements)
        {
            try
            {
                var deletedFarmerArchivements = await _FarmerArchivementsRepository.DeleteFarmerArchivements(IdFarmerArchivements);
                if (deletedFarmerArchivements == false)
                {
                    return NotFound();
                }
                return Ok(deletedFarmerArchivements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}