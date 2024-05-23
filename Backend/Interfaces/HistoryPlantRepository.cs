using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IHistoryPlantRepository
    {
        Task<List<HistoryPlant>> GetHistoryPlants();
        Task<HistoryPlant> GetHistoryPlant(int IdHistoryPlant);
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