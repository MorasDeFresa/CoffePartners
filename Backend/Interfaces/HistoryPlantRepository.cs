using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public class GroupedHistoryPlant
    {
        public required int IdPlant { get; set; }
        public required float PositionX { get; set; }
        public required float PositionZ { get; set; }
        public required string ActualPlantState { get; set; }
    }
    public class DetailHistoryPlant
    {
        public required int IdHistoryPlant { get; set; }
        public required string PlantState { get; set; }
        public required DateTime DatePlantProcess { get; set; }
    }

    public interface IHistoryPlantRepository
    {
        Task<List<HistoryPlant>> GetHistoryPlants();
        Task<HistoryPlant> GetHistoryPlant(int IdHistoryPlant);
        Task<List<DetailHistoryPlant>> GetDetailHistoryPlant(int IdPlant);
        Task<List<GroupedHistoryPlant>> GetGroupedHistoryPlant();
        Task<HistoryPlant> CreateHistoryPlant(HistoryPlant HistoryPlant);
        Task<HistoryPlant> UpdateHistoryPlant(HistoryPlant HistoryPlant);
        Task<bool> DeleteHistoryPlant(int IdHistoryPlant);
    }

    public class HistoryPlantRepository : IHistoryPlantRepository
    {
        private readonly DataContext _db;

        public HistoryPlantRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<HistoryPlant> CreateHistoryPlant(HistoryPlant HistoryPlant)
        {
            await _db.HistoryPlants.AddAsync(HistoryPlant);
            _db.SaveChanges();
            return HistoryPlant;
        }

        public async Task<bool> DeleteHistoryPlant(int IdHistoryPlant)
        {
            var HistoryPlantAtDelete = await GetHistoryPlant(IdHistoryPlant);
            _db.HistoryPlants.Remove(HistoryPlantAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<DetailHistoryPlant>> GetDetailHistoryPlant(int IdPlant)
        {
            var groupedHistoryPlants = await _db.HistoryPlants
            .Where(h => h.IdPlant == IdPlant)
            .Select(g => new
            {
                g.IdHistoryPlant,
                g.DatePlantProcess,
                g.IdPlantState
            })
            .ToListAsync();

            var plantStateIds = groupedHistoryPlants.Select(gh => gh.IdPlantState).Distinct().ToList();

            var plantStateNames = await _db.PlantStates
            .Where(tq => plantStateIds.Contains(tq.IdPlantState))
            .ToDictionaryAsync(tq => tq.IdPlantState, tq => tq.NamePlantState);

            var result = groupedHistoryPlants.Select(gh => new DetailHistoryPlant
            {
                IdHistoryPlant = gh.IdHistoryPlant,
                DatePlantProcess = gh.DatePlantProcess,
                PlantState = plantStateNames.ContainsKey(gh.IdPlantState) ? plantStateNames[gh.IdPlantState] : null
            }).ToList();

            return result;
        }

        public async Task<List<GroupedHistoryPlant>> GetGroupedHistoryPlant()
        {
            var groupedHistoryPlants = await _db.HistoryPlants
            .GroupBy(h => h.IdPlant)
            .Select(g => new
            {
                IdPlant = g.Key,
                IdPlantState = g.OrderByDescending(h => h.DatePlantProcess).Select(h => h.IdPlantState).FirstOrDefault()
            }).ToListAsync();

            var plantStateIds = groupedHistoryPlants.Select(gh => gh.IdPlantState).Distinct().ToList();

            var plantStateNames = await _db.PlantStates
            .Where(tq => plantStateIds.Contains(tq.IdPlantState))
            .ToDictionaryAsync(tq => tq.IdPlantState, tq => tq.NamePlantState);

            var plantIds = groupedHistoryPlants.Select(gh => gh.IdPlant).Distinct().ToList();

            var plantPositionX = await _db.Plants
            .Where(tq => plantIds.Contains(tq.IdPlant))
            .ToDictionaryAsync(tq => tq.IdPlant, tq => tq.PositionX);

            var plantPositionZ = await _db.Plants
            .Where(tq => plantIds.Contains(tq.IdPlant))
            .ToDictionaryAsync(tq => tq.IdPlant, tq => tq.PositionZ);

            var result = groupedHistoryPlants.Select(gh => new GroupedHistoryPlant
            {
                IdPlant = gh.IdPlant,
                PositionX = plantPositionX.ContainsKey(gh.IdPlant) ? plantPositionX[gh.IdPlant] : 0,
                PositionZ = plantPositionZ.ContainsKey(gh.IdPlant) ? plantPositionZ[gh.IdPlant] : 0,
                ActualPlantState = plantStateNames.ContainsKey(gh.IdPlantState) ? plantStateNames[gh.IdPlantState] : null

            }).ToList();
            return result;


        }

        public async Task<HistoryPlant> GetHistoryPlant(int IdHistoryPlant)
        {
            return await _db.HistoryPlants.FirstOrDefaultAsync(cu => cu.IdHistoryPlant == IdHistoryPlant);
        }

        public async Task<List<HistoryPlant>> GetHistoryPlants()
        {
            return await _db.HistoryPlants.ToListAsync();
        }

        public async Task<HistoryPlant> UpdateHistoryPlant(HistoryPlant HistoryPlant)
        {
            _db.HistoryPlants.Update(HistoryPlant);
            await _db.SaveChangesAsync();
            return HistoryPlant;
        }
    }
}