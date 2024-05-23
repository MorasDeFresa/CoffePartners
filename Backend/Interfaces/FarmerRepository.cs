using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IFarmerRepository
    {
        Task<List<Farmer>> GetFarmers();
        Task<Farmer> GetFarmer(int IdFarmer);
        Task<Farmer> CreateFarmer(Farmer Farmer);
        Task<Farmer> UpdateFarmer(Farmer Farmer);
        Task<bool> DeleteFarmer(int IdFarmer);
    }

    public class FarmerRepository : IFarmerRepository
    {
        private readonly DataContext _db;

        public FarmerRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Farmer> CreateFarmer(Farmer Farmer)
        {
            await _db.Farmers.AddAsync(Farmer);
            _db.SaveChanges();
            return Farmer;
        }

        public async Task<bool> DeleteFarmer(int IdFarmer)
        {
            var FarmerAtDelete = await GetFarmer(IdFarmer);
            _db.Farmers.Remove(FarmerAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Farmer> GetFarmer(int IdFarmer)
        {
            return await _db.Farmers.FirstOrDefaultAsync(cu => cu.IdFarmer == IdFarmer);
        }

        public async Task<List<Farmer>> GetFarmers()
        {
            return await _db.Farmers.ToListAsync();
        }

        public async Task<Farmer> UpdateFarmer(Farmer Farmer)
        {
            _db.Farmers.Update(Farmer);
            await _db.SaveChangesAsync();
            return Farmer;
        }
    }
}