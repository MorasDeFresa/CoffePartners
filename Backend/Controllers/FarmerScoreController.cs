using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class FarmerScorePost()
    {
        public required int IdFarmer { get; set; }
        public required float PointScore { get; set; }
    }

    public class FarmerScorePut()
    {
        public int? IdFarmer { get; set; }
        public float? PointScore { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class FarmerScoreController : ControllerBase
    {
        private readonly IFarmerScoreRepository _FarmerScoreRepository;
        private readonly IScoreRepository _ScoreRepository;

        public FarmerScoreController(IFarmerScoreRepository FarmerScoreRepository, IScoreRepository ScoreRepository)
        {
            _FarmerScoreRepository = FarmerScoreRepository;
            _ScoreRepository = ScoreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<FarmerScore>>> GetFarmerScores()
        {
            try
            {
                return Ok(await _FarmerScoreRepository.GetFarmerScores());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdFarmerScore}")]
        public async Task<ActionResult<FarmerScore>> GetFarmerScore(int IdFarmerScore)
        {
            try
            {
                var FarmerScore = await _FarmerScoreRepository.GetFarmerScore(IdFarmerScore);
                if (FarmerScore == null)
                {
                    return NotFound("FarmerScore not found");
                }
                return Ok(FarmerScore);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<FarmerScore>> CreateFarmerScore(FarmerScorePost FarmerScorePost)
        {
            var IdScore = await _ScoreRepository.GetIdScoreByPoint(FarmerScorePost.PointScore);
            try
            {

                var FarmerScore = new FarmerScore
                {
                    IdFarmer = FarmerScorePost.IdFarmer,
                    IdScore = IdScore,
                    DateScore = DateTime.Now,
                    PointScore = FarmerScorePost.PointScore
                };

                var createdFarmerScore = await _FarmerScoreRepository.CreateFarmerScore(FarmerScore);
                if (createdFarmerScore == null)
                {
                    return BadRequest("create FarmerScore");
                }
                return CreatedAtAction(nameof(GetFarmerScores), new { IdFarmerScore = createdFarmerScore.IdFarmerScore }, createdFarmerScore);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdFarmerScore}")]
        public async Task<ActionResult<FarmerScore>> UpdateFarmerScore(int IdFarmerScore, FarmerScorePut FarmerScorePut)
        {
            try
            {
                var FarmerScore = await _FarmerScoreRepository.GetFarmerScore(IdFarmerScore);
                if (FarmerScore == null) return BadRequest("update FarmerScore");
                if (FarmerScorePut.PointScore != null)
                {
                    FarmerScore.PointScore = (float)FarmerScorePut.PointScore;
                    FarmerScore.IdScore = await _ScoreRepository.GetIdScoreByPoint(FarmerScore.PointScore);
                }
                FarmerScore.DateScore = DateTime.Now;

                var updatedFarmerScore = await _FarmerScoreRepository.UpdateFarmerScore(FarmerScore);
                if (updatedFarmerScore == null)
                {
                    return NotFound();
                }
                return Ok(updatedFarmerScore);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdFarmerScore}")]
        public async Task<ActionResult<FarmerScore>> DeleteFarmerScore(int IdFarmerScore)
        {
            try
            {
                var deletedFarmerScore = await _FarmerScoreRepository.DeleteFarmerScore(IdFarmerScore);
                if (deletedFarmerScore == false)
                {
                    return NotFound();
                }
                return Ok(deletedFarmerScore);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}