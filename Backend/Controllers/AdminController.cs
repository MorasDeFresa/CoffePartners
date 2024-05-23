using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AdminPost()
    {
        public required int IdUser { get; set; }
    }

    public class AdminPut()
    {
        public bool? IsActive { get; set; }
        public int? IdUser { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _AdminRepository;

        public AdminController(IAdminRepository AdminRepository)
        {
            _AdminRepository = AdminRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAdmins()
        {
            try
            {
                return Ok(await _AdminRepository.GetAdmins());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{IdAdmin}")]
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

        [HttpPost]
        public async Task<ActionResult<Admin>> CreateAdmin(AdminPost AdminPost)
        {
            try
            {
                var Admin = new Admin
                {
                    IdUser = AdminPost.IdUser,
                    DateAdminState = DateTime.Now
                };

                var createdAdmin = await _AdminRepository.CreateAdmin(Admin);
                if (createdAdmin == null)
                {
                    return BadRequest("create Admin");
                }
                return CreatedAtAction(nameof(GetAdmins), new { IdAdmin = createdAdmin.IdAdmin }, createdAdmin);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{IdAdmin}")]
        public async Task<ActionResult<Admin>> UpdateAdmin(int IdAdmin, AdminPut AdminPut)
        {
            try
            {
                var Admin = await _AdminRepository.GetAdmin(IdAdmin);
                if (Admin == null) return BadRequest("update Admin");
                if (AdminPut.IdUser != null) Admin.IdUser = (int)AdminPut.IdUser;
                if (AdminPut.IsActive != null) Admin.IsActive = (bool)AdminPut.IsActive;
                Admin.DateAdminState = DateTime.Now;
                var updatedAdmin = await _AdminRepository.UpdateAdmin(Admin);
                if (updatedAdmin == null)
                {
                    return NotFound();
                }
                return Ok(updatedAdmin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{IdAdmin}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(int IdAdmin)
        {
            try
            {
                var deletedAdmin = await _AdminRepository.DeleteAdmin(IdAdmin);
                if (deletedAdmin == false)
                {
                    return NotFound();
                }
                return Ok(deletedAdmin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}