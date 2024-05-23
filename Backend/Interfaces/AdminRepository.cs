using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAdmins();
        Task<Admin> GetAdmin(int IdAdmin);
        Task<Admin> CreateAdmin(Admin Admin);
        Task<Admin> UpdateAdmin(Admin Admin);
        Task<bool> DeleteAdmin(int IdAdmin);
    }

    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _db;

        public AdminRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Admin> CreateAdmin(Admin Admin)
        {
            await _db.Admins.AddAsync(Admin);
            _db.SaveChanges();
            return Admin;
        }

        public async Task<bool> DeleteAdmin(int IdAdmin)
        {
            var AdminAtDelete = await GetAdmin(IdAdmin);
            _db.Admins.Remove(AdminAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Admin> GetAdmin(int IdAdmin)
        {
            return await _db.Admins.FirstOrDefaultAsync(cu => cu.IdAdmin == IdAdmin);
        }

        public async Task<List<Admin>> GetAdmins()
        {
            return await _db.Admins.ToListAsync();
        }

        public async Task<Admin> UpdateAdmin(Admin Admin)
        {
            _db.Admins.Update(Admin);
            await _db.SaveChangesAsync();
            return Admin;
        }
    }
}