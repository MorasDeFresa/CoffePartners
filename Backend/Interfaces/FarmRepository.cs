using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IFarmRepository
    {
        Task<List<Farm>> GetFarms();
        Task<Farm> GetFarm(int IdFarm);
        Task<Farm> CreateFarm(Farm Farm);
        Task<Farm> UpdateFarm(Farm Farm);
        Task<bool> DeleteFarm(int IdFarm);
    }

    public class FarmRepository : IFarmRepository
    {
        private readonly DataContext _db;

        public FarmRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Farm> CreateFarm(Farm Farm)
        {
            await _db.Farms.AddAsync(Farm);
            _db.SaveChanges();
            return Farm;
        }

        public async Task<bool> DeleteFarm(int IdFarm)
        {
            var FarmAtDelete = await GetFarm(IdFarm);
            _db.Farms.Remove(FarmAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Farm> GetFarm(int IdFarm)
        {
            return await _db.Farms.FirstOrDefaultAsync(cu => cu.IdFarm == IdFarm);
        }

        public async Task<List<Farm>> GetFarms()
        {
            return await _db.Farms.ToListAsync();
        }

        public async Task<Farm> UpdateFarm(Farm Farm)
        {
            _db.Farms.Update(Farm);
            await _db.SaveChangesAsync();
            return Farm;
        }
    }
}