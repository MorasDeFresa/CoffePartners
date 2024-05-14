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

    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            return Ok(await _playerService.getPlayers());
        }

        [HttpGet("{IdPlayer}")]
        public async Task<ActionResult<Player>> GetPlayer(int IdPlayer)
        {
            var clase = await _playerService.getPlayer(IdPlayer);
            if (clase == null)
            {
                return NotFound("Clase no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(string EmailPlayer, string PasswordPlayer, string NicknamePlayer)
        {
            try
            {
                var createdClass = await _playerService.createPlayer(EmailPlayer, PasswordPlayer, NicknamePlayer);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear el cultivo");
                }
                return CreatedAtAction(nameof(GetPlayers), new { IdPlayer = createdClass.IdPlayer }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cultivo: {ex.Message}");
            }
        }

        [HttpPut("{IdPlayer}")]
        public async Task<ActionResult<Player>> UpdatePlayer(int IdPlayer, string EmailPlayer, string PasswordPlayer, string NicknamePlayer)
        {
            var updatedClass = await _playerService.updatePlayer(IdPlayer, EmailPlayer, PasswordPlayer, NicknamePlayer);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdPlayer}")]
        public async Task<ActionResult<Player>> DeletePlayer(int IdPlayer)
        {
            var deletedClass = await _playerService.deletePlayer(IdPlayer);
            if (deletedClass == null)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("El nombre de usuario y la contraseña son obligatorios");
            }

            var user = await _playerService.login(userName, password);

            if (user != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
    }

}