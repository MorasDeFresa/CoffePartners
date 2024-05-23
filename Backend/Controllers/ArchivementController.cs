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

    public class ArchivementController : ControllerBase
    {
        private readonly IArchivementRepository _ArchivementRepository;

        public ArchivementController(IArchivementRepository ArchivementRepository)
        {
            _ArchivementRepository = ArchivementRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Archivement>>> GetArchivements()
        {
            return Ok(await _ArchivementRepository.GetArchivements());
        }

        [HttpGet("{IdArchivement}")]
        public async Task<ActionResult<Archivement>> GetArchivement(int IdArchivement)
        {
            var clase = await _ArchivementRepository.GetArchivement(IdArchivement);
            if (clase == null)
            {
                return NotFound("Archivement no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Archivement>> CreateArchivement(Archivement Archivement)
        {
            try
            {
                var createdClass = await _ArchivementRepository.CreateArchivement(Archivement);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear Archivement");
                }
                return CreatedAtAction(nameof(GetArchivements), new { IdArchivement = createdClass.IdArchivement }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Archivement: {ex.Message}");
            }
        }

        [HttpPut("{IdArchivement}")]
        public async Task<ActionResult<Archivement>> UpdateArchivement(Archivement Archivement)
        {
            var updatedClass = await _ArchivementRepository.UpdateArchivement(Archivement);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdArchivement}")]
        public async Task<ActionResult<Archivement>> DeleteArchivement(int IdArchivement)
        {
            var deletedClass = await _ArchivementRepository.DeleteArchivement(IdArchivement);
            if (deletedClass == false)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}