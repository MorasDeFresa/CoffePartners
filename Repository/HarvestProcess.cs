using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface IHarvestProcessRepository
    {
        Task<List<HarvestProcess>> GetHarvestProcesss();
        Task<HarvestProcess> GetHarvestProcess(int IdHarvestProcess);
        Task<HarvestProcess> CreateHarvestProcess(int IdCultivationHarvest, int IdTypeProcess, float HeightWastedGrain);
        Task<HarvestProcess> UpdateHarvestProcess(HarvestProcess HarvestProcess);
        Task<bool> DeleteHarvestProcess(int IdHarvestProcess);
    }

    public class HarvestProcessRepository : IHarvestProcessRepository
    {
        private readonly DataContext _db;

        public HarvestProcessRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<HarvestProcess> CreateHarvestProcess(int IdCultivationHarvest, int IdTypeProcess, float HeightWastedGrain)
        {
            var newHarvestProcess = new HarvestProcess()
            {
                IdCultivationHarvest = IdCultivationHarvest,
                IdTypeProcess = IdTypeProcess,
                HeightWastedGrain = HeightWastedGrain
            };

            await _db.HarvestProcesss.AddAsync(newHarvestProcess);

            _db.SaveChanges();

            return newHarvestProcess;
        }

        public async Task<List<HarvestProcess>> GetHarvestProcesss()
        {
            return await _db.HarvestProcesss.ToListAsync();
        }

        public async Task<HarvestProcess> GetHarvestProcess(int IdHarvestProcess)
        {
            return await _db.HarvestProcesss.FirstOrDefaultAsync(ch => ch.IdHarvestProcess == IdHarvestProcess);
        }


        public async Task<HarvestProcess> UpdateHarvestProcess(HarvestProcess HarvestProcess)
        {
            _db.HarvestProcesss.Update(HarvestProcess);
            await _db.SaveChangesAsync();
            return HarvestProcess;
        }

        public async Task<bool> DeleteHarvestProcess(int IdHarvestProcess)
        {
            var cultivationHarvest = await GetHarvestProcess(IdHarvestProcess);

            _db.HarvestProcesss.Remove(cultivationHarvest);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}