using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IPlantStatesRepository
    {
        Task<List<PlantStates>> GetPlantStatess();
        Task<PlantStates> GetPlantStates(int IdPlantStates);
        Task<PlantStates> CreatePlantStates(PlantStates PlantStates);
        Task<PlantStates> UpdatePlantStates(PlantStates PlantStates);
        Task<bool> DeletePlantStates(int IdPlantStates);
    }

    public class PlantStatesRepository : IPlantStatesRepository
    {
        private readonly DataContext _db;

        public PlantStatesRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<PlantStates> CreatePlantStates(PlantStates PlantStates)
        {
            await _db.PlantStates.AddAsync(PlantStates);
            _db.SaveChanges();
            return PlantStates;
        }

        public async Task<bool> DeletePlantStates(int IdPlantStates)
        {
            var PlantStatesAtDelete = await GetPlantStates(IdPlantStates);
            _db.PlantStates.Remove(PlantStatesAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<PlantStates> GetPlantStates(int IdPlantStates)
        {
            return await _db.PlantStates.FirstOrDefaultAsync(cu => cu.IdPlantState == IdPlantStates);
        }

        public async Task<List<PlantStates>> GetPlantStatess()
        {
            return await _db.PlantStates.ToListAsync();
        }

        public async Task<PlantStates> UpdatePlantStates(PlantStates PlantStates)
        {
            _db.PlantStates.Update(PlantStates);
            await _db.SaveChangesAsync();
            return PlantStates;
        }
    }
}