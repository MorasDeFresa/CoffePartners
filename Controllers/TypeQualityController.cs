using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoffePartners.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TypeQualityController : Controller
    {
        private readonly ITypeQualityRepository _typeQualityRepository;
        public TypeQualityController(ITypeQualityRepository typeQualityRepository)
        {
            _typeQualityRepository = typeQualityRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TypeQuality>))]
        public IActionResult getTypeQualitys()
        {
            var TypeQualitys = _typeQualityRepository.getTypeQualitys();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(TypeQualitys);
        }
    }
}