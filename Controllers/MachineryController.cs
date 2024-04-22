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

    public class MachineryController : Controller
    {
        private readonly IMachineryRepository _machineryRepository;
        public MachineryController(IMachineryRepository MachineryRepository)
        {
            _machineryRepository = MachineryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Machinery>))]
        public IActionResult getMachinerys()
        {
            var Machinerys = _machineryRepository.getMachinerys();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(Machinerys);
        }
    }
}