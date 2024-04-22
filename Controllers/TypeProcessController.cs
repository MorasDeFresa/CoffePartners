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

    public class TypeProcessController : Controller
    {
        private readonly ITypeProcessRepository _typeProcessRepository;
        public TypeProcessController(ITypeProcessRepository TypeProcessRepository)
        {
            _typeProcessRepository = TypeProcessRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TypeProcess>))]
        public IActionResult getTypeProcesss()
        {
            var TypeProcesss = _typeProcessRepository.getTypeProcesss();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(TypeProcesss);
        }
    }
}