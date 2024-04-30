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

    public class MachineryController : ControllerBase
    {
        private readonly IMachineryService _machineryService;

        public MachineryController(IMachineryService machineryService)
        {
            _machineryService = machineryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Machinery>>> GetMachinerys()
        {
            return Ok(await _machineryService.getMachinerys());
        }

        [HttpGet("{IdMachinery}")]
        public async Task<ActionResult<Machinery>> GetMachinery(int IdMachinery)
        {
            var clase = await _machineryService.getMachinery(IdMachinery);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Machinery>> CreateMachinery(string NameMachine, string DescriptionMachine, float PriceMachine)
        {
            try
            {
                var createdClass = await _machineryService.createMachinery(NameMachine, DescriptionMachine, PriceMachine);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear el cultivo");
                }
                return CreatedAtAction(nameof(GetMachinerys), new { IdMachinery = createdClass.IdMachinery }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cultivo: {ex.Message}");
            }
        }

        [HttpPut("{IdMachinery}")]
        public async Task<ActionResult<Machinery>> UpdateMachinery(int IdMachinery, string NameMachine, string DescriptionMachine, float PriceMachine)
        {
            var updatedClass = await _machineryService.updateMachinery(IdMachinery, NameMachine, DescriptionMachine, PriceMachine);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdMachinery}")]
        public async Task<ActionResult<Machinery>> DeleteMachinery(int IdMachinery)
        {
            var deletedClass = await _machineryService.deleteMachinery(IdMachinery);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}