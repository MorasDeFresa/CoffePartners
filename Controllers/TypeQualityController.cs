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

    public class TypeQualityController : ControllerBase
    {
        private readonly ITypeQualityService _typeQualityService;

        public TypeQualityController(ITypeQualityService typeQualityService)
        {
            _typeQualityService = typeQualityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeQuality>>> GetTypeQualitys()
        {
            return Ok(await _typeQualityService.getTypeQualitys());
        }

        [HttpGet("{IdTypeQuality}")]
        public async Task<ActionResult<TypeQuality>> GetTypeQuality(int IdTypeQuality)
        {
            var clase = await _typeQualityService.getTypeQuality(IdTypeQuality);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<TypeQuality>> CreateTypeQuality(string NameQuality, int PriceByGr)
        {
            try
            {
                var createdClass = await _typeQualityService.createTypeQuality(NameQuality, PriceByGr);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear el cultivo");
                }
                return CreatedAtAction(nameof(GetTypeQualitys), new { IdTypeQuality = createdClass.IdTypeQuality }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cultivo: {ex.Message}");
            }
        }

        [HttpPut("{IdTypeQuality}")]
        public async Task<ActionResult<TypeQuality>> UpdateTypeQuality(int IdTypeQuality, string NameQuality, int PriceByGr)
        {
            var updatedClass = await _typeQualityService.updateTypeQuality(IdTypeQuality, NameQuality, PriceByGr);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdTypeQuality}")]
        public async Task<ActionResult<TypeQuality>> DeleteTypeQuality(int IdTypeQuality)
        {
            var deletedClass = await _typeQualityService.deleteTypeQuality(IdTypeQuality);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}