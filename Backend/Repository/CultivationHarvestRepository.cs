using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface ICultivationHarvestRepository
    {
        Task<List<CultivationHarvest>> GetCultivationHarvests();
        Task<CultivationHarvest> GetCultivationHarvest(int IdCultivationHarvest);
        Task<CultivationHarvest> CreateCultivationHarvest(int IdCultivation, int IdHarvest, float WeightHarvest);
        Task<CultivationHarvest> UpdateCultivationHarvest(CultivationHarvest CultivationHarvest);
        Task<bool> DeleteCultivationHarvest(int IdCultivationHarvest);
    }

    public class CultivationHarvestRepository : ICultivationHarvestRepository
    {
        private readonly DataContext _db;

        public CultivationHarvestRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<CultivationHarvest> CreateCultivationHarvest(int IdCultivation, int IdHarvest, float WeightHarvest)
        {
            var newCultivationHarvest = new CultivationHarvest()
            {
                IdCultivation = IdCultivation,
                IdHarvest = IdHarvest,
                WeightHarvest = WeightHarvest
            };

            await _db.CultivationHarvests.AddAsync(newCultivationHarvest);

            _db.SaveChanges();

            return newCultivationHarvest;
        }

        public async Task<List<CultivationHarvest>> GetCultivationHarvests()
        {
            return await _db.CultivationHarvests.ToListAsync();
        }

        public async Task<CultivationHarvest> GetCultivationHarvest(int IdCultivationHarvest)
        {
            return await _db.CultivationHarvests.FirstOrDefaultAsync(ch => ch.IdCultivationHarvest == IdCultivationHarvest);
        }


        public async Task<CultivationHarvest> UpdateCultivationHarvest(CultivationHarvest CultivationHarvest)
        {
            _db.CultivationHarvests.Update(CultivationHarvest);
            await _db.SaveChangesAsync();
            return CultivationHarvest;
        }

        public async Task<bool> DeleteCultivationHarvest(int IdCultivationHarvest)
        {
            var cultivationHarvest = await GetCultivationHarvest(IdCultivationHarvest);

            _db.CultivationHarvests.Remove(cultivationHarvest);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}