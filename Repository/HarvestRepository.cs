using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface IHarvestRepository
    {
        Task<List<Harvest>> GetHarvests();
        Task<Harvest> GetHarvest(int IdHarvest);
        Task<Harvest> CreateHarvest(DateTime DateHarvest, int IdTypeQuality);
        Task<Harvest> UpdateHarvest(Harvest Harvest);
        Task<bool> DeleteHarvest(int IdHarvest);
    }

    public class HarvestRepository : IHarvestRepository
    {
        private readonly DataContext _db;

        public HarvestRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Harvest> CreateHarvest(DateTime DateHarvest, int IdTypeQuality)
        {
            var newHarvest = new Harvest()
            {
                DateHarvest = DateHarvest,
                IdTypeQuality = IdTypeQuality
            };

            await _db.Harvests.AddAsync(newHarvest);

            _db.SaveChanges();

            return newHarvest;
        }

        public async Task<List<Harvest>> GetHarvests()
        {
            return await _db.Harvests.ToListAsync();
        }

        public async Task<Harvest> GetHarvest(int IdHarvest)
        {
            return await _db.Harvests.FirstOrDefaultAsync(ch => ch.IdHarvest == IdHarvest);
        }


        public async Task<Harvest> UpdateHarvest(Harvest Harvest)
        {
            _db.Harvests.Update(Harvest);
            await _db.SaveChangesAsync();
            return Harvest;
        }

        public async Task<bool> DeleteHarvest(int IdHarvest)
        {
            var cultivationHarvest = await GetHarvest(IdHarvest);

            _db.Harvests.Remove(cultivationHarvest);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}