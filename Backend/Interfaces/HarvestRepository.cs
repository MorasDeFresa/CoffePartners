using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public class GroupedHarvest
    {
        public required int IdPlant { get; set; }
        public required float PositionX { get; set; }
        public required float PositionZ { get; set; }
        public required float WeightHarvest { get; set; }
        public required string TypeQuality { get; set; }
    }

    public class DetailHarvest
    {
        public required float WeightHarvest { get; set; }
        public required string TypeQuality { get; set; }
        public required DateTime DateBasketProcess { get; set; }
    }

    public interface IHarvestRepository
    {
        Task<List<Harvest>> GetHarvests();
        Task<Harvest> GetHarvest(int IdHarvest);
        Task<List<DetailHarvest>> GetDetailHarvests(int IdPlant);
        Task<List<GroupedHarvest>> GetGroupHarvests();
        Task<Harvest> CreateHarvest(Harvest Harvest);
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

        public async Task<Harvest> CreateHarvest(Harvest Harvest)
        {
            await _db.Harvests.AddAsync(Harvest);
            _db.SaveChanges();
            return Harvest;
        }

        public async Task<bool> DeleteHarvest(int IdHarvest)
        {
            var HarvestAtDelete = await GetHarvest(IdHarvest);
            _db.Harvests.Remove(HarvestAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Harvest> GetHarvest(int IdHarvest)
        {
            return await _db.Harvests.FirstOrDefaultAsync(cu => cu.IdHarvest == IdHarvest);
        }

        public async Task<List<Harvest>> GetHarvests()
        {
            return await _db.Harvests.ToListAsync();
        }

        public async Task<List<GroupedHarvest>> GetGroupHarvests()
        {
            var groupedHarvests = await _db.Harvests
            .GroupBy(h => h.IdPlant)
            .Select(g => new
            {
                IdPlant = g.Key,
                WeightHarvest = g.Sum(h => h.WeightHarvest),
                MostFrequentTypeQuality = g
                    .GroupBy(h => h.IdTypeQuality)
                    .OrderByDescending(g2 => g2.Count())
                    .Select(g2 => g2.Key)
                    .FirstOrDefault()
            })
            .ToListAsync();

            var typeQualityIds = groupedHarvests.Select(gh => gh.MostFrequentTypeQuality).Distinct().ToList();

            var typeQualityNames = await _db.TypeQualitys
            .Where(tq => typeQualityIds.Contains(tq.IdTypeQuality))
            .ToDictionaryAsync(tq => tq.IdTypeQuality, tq => tq.NameTypeQuality);

            var plantIds = groupedHarvests.Select(gh => gh.IdPlant).Distinct().ToList();

            var plantPositionX = await _db.Plants
            .Where(tq => plantIds.Contains(tq.IdPlant))
            .ToDictionaryAsync(tq => tq.IdPlant, tq => tq.PositionX);

            var plantPositionZ = await _db.Plants
            .Where(tq => plantIds.Contains(tq.IdPlant))
            .ToDictionaryAsync(tq => tq.IdPlant, tq => tq.PositionZ);

            var result = groupedHarvests.Select(gh => new GroupedHarvest
            {
                IdPlant = gh.IdPlant,
                WeightHarvest = gh.WeightHarvest,
                TypeQuality = typeQualityNames.ContainsKey(gh.MostFrequentTypeQuality) ? typeQualityNames[gh.MostFrequentTypeQuality] : null,
                PositionX = plantPositionX.ContainsKey(gh.IdPlant) ? plantPositionX[gh.IdPlant] : 0,
                PositionZ = plantPositionZ.ContainsKey(gh.IdPlant) ? plantPositionZ[gh.IdPlant] : 0,

            }).ToList();
            return result;
        }

        public async Task<Harvest> UpdateHarvest(Harvest Harvest)
        {
            _db.Harvests.Update(Harvest);
            await _db.SaveChangesAsync();
            return Harvest;
        }

        public async Task<List<DetailHarvest>> GetDetailHarvests(int IdPlant)
        {
            var groupedHarvests = await _db.Harvests
            .Where(h => h.IdPlant == IdPlant)
            .Select(g => new
            {
                g.WeightHarvest,
                g.DateBasketProcess,
                g.IdTypeQuality
            })
            .ToListAsync();


            var typeQualityIds = groupedHarvests.Select(gh => gh.IdTypeQuality).Distinct().ToList();

            var typeQualityNames = await _db.TypeQualitys
            .Where(tq => typeQualityIds.Contains(tq.IdTypeQuality))
            .ToDictionaryAsync(tq => tq.IdTypeQuality, tq => tq.NameTypeQuality);

            var result = groupedHarvests.Select(gh => new DetailHarvest
            {
                WeightHarvest = gh.WeightHarvest,
                DateBasketProcess = gh.DateBasketProcess,
                TypeQuality = typeQualityNames.ContainsKey(gh.IdTypeQuality) ? typeQualityNames[gh.IdTypeQuality] : null
            }).ToList();

            return result;
        }
    }
}