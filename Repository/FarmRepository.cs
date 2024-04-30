using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface IFarmRepository
    {
        Task<List<Farm>> GetFarms();
        Task<Farm> GetFarm(int IdFarm);
        Task<Farm> CreateFarm(string NameFarm, int IdPlayer, float SizeFarm);
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

        public async Task<Farm> CreateFarm(string NameFarm, int IdPlayer, float SizeFarm)
        {
            var newFarm = new Farm()
            {
                NameFarm = NameFarm,
                IdPlayer = IdPlayer,
                SizeFarm = SizeFarm
            };

            await _db.Farms.AddAsync(newFarm);

            _db.SaveChanges();

            return newFarm;
        }

        public async Task<List<Farm>> GetFarms()
        {
            return await _db.Farms.ToListAsync();
        }

        public async Task<Farm> GetFarm(int IdFarm)
        {
            return await _db.Farms.FirstOrDefaultAsync(ch => ch.IdFarm == IdFarm);
        }


        public async Task<Farm> UpdateFarm(Farm Farm)
        {
            _db.Farms.Update(Farm);
            await _db.SaveChangesAsync();
            return Farm;
        }

        public async Task<bool> DeleteFarm(int IdFarm)
        {
            var cultivationHarvest = await GetFarm(IdFarm);

            _db.Farms.Remove(cultivationHarvest);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}