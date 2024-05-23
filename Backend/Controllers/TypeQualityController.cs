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

    public class TypeQualityController : ControllerBase
    {
        private readonly ITypeQualityRepository _TypeQualityRepository;

        public TypeQualityController(ITypeQualityRepository TypeQualityRepository)
        {
            _TypeQualityRepository = TypeQualityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeQuality>>> GetTypeQualitys()
        {
            return Ok(await _TypeQualityRepository.GetTypeQualitys());
        }

        [HttpGet("{IdTypeQuality}")]
        public async Task<ActionResult<TypeQuality>> GetTypeQuality(int IdTypeQuality)
        {
            var clase = await _TypeQualityRepository.GetTypeQuality(IdTypeQuality);
            if (clase == null)
            {
                return NotFound("TypeQuality no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<TypeQuality>> CreateTypeQuality(TypeQuality typeQuality)
        {
            try
            {
                var createdClass = await _TypeQualityRepository.CreateTypeQuality(typeQuality);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear TypeQuality");
                }
                return CreatedAtAction(nameof(GetTypeQualitys), new { IdTypeQuality = createdClass.IdTypeQuality }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear TypeQuality: {ex.Message}");
            }
        }

        [HttpPut("{IdTypeQuality}")]
        public async Task<ActionResult<TypeQuality>> UpdateTypeQuality(TypeQuality typeQuality)
        {
            var updatedClass = await _TypeQualityRepository.UpdateTypeQuality(typeQuality);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdTypeQuality}")]
        public async Task<ActionResult<TypeQuality>> DeleteTypeQuality(int IdTypeQuality)
        {
            var deletedClass = await _TypeQualityRepository.DeleteTypeQuality(IdTypeQuality);
            if (deletedClass == false)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}