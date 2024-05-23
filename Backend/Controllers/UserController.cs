using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace Backend.Controllers
{
    public class LoginUser()
    {
        public required string EmailUser { get; set; }
        public required string PasswordUser { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        private readonly IAdminRepository _AdminRepository;
        private readonly IFarmerRepository _FarmerRepository;

        public UserController(IUserRepository UserRepository, IAdminRepository developerRepository, IFarmerRepository FarmerRepository)
        {
            _UserRepository = UserRepository;
            _AdminRepository = developerRepository;
            _FarmerRepository = FarmerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _UserRepository.GetUsers());
        }

        [HttpGet("{IdUser}")]
        public async Task<ActionResult<User>> GetUser(int IdUser)
        {
            var clase = await _UserRepository.GetUser(IdUser);
            if (clase == null)
            {
                return NotFound("User no encontrada");
            }
            return Ok(clase);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User User)
        {
            try
            {
                var createdClass = await _UserRepository.CreateUser(User);
                if (createdClass == null)
                {
                    return BadRequest("No se pudo crear User");
                }
                return CreatedAtAction(nameof(GetUsers), new { IdUser = createdClass.IdUser }, createdClass);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear User: {ex.Message}");
            }
        }

        [HttpPost("/sign-in")]
        public async Task<IActionResult> LoginUser(LoginUser User)
        {
            try
            {
                var user = await _UserRepository.LoginUser(User.EmailUser, User.PasswordUser);
                if (user[0] == 1) return RedirectToAction(nameof(GetAdmin), new { IdAdmin = user[1] });
                else if (user[0] == 0) return RedirectToAction(nameof(GetFarmer), new { IdFarmer = user[1] });
                return NotFound("User not found");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear User: {ex.Message}");
            }
        }

        [HttpGet("/sign-in/Farmer/{IdFarmer}")]
        public async Task<ActionResult<Farmer>> GetFarmer(int IdFarmer)
        {
            try
            {
                var Farmer = await _FarmerRepository.GetFarmer(IdFarmer);
                if (Farmer == null)
                {
                    return NotFound("Farmer not found");
                }
                return Ok(Farmer);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("/sign-in/developer/{IdAdmin}")]
        public async Task<ActionResult<Admin>> GetAdmin(int IdAdmin)
        {
            try
            {
                var Admin = await _AdminRepository.GetAdmin(IdAdmin);
                if (Admin == null)
                {
                    return NotFound("Admin not found");
                }
                return Ok(Admin);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdUser}")]
        public async Task<ActionResult<User>> UpdateUser(User User)
        {
            var updatedClass = await _UserRepository.UpdateUser(User);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }

        [HttpDelete("{IdUser}")]
        public async Task<ActionResult<User>> DeleteUser(int IdUser)
        {
            var deletedClass = await _UserRepository.DeleteUser(IdUser);
            if (deletedClass == false)
            {
                return NotFound();
            }
            return Ok(deletedClass);
        }
    }

}