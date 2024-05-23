using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IPlantRepository
    {
        Task<List<Plant>> GetPlants();
        Task<Plant> GetPlant(int IdPlant);
        Task<Plant> CreatePlant(Plant Plant);
        Task<Plant> UpdatePlant(Plant Plant);
        Task<bool> DeletePlant(int IdPlant);
    }

    public class PlantRepository : IPlantRepository
    {
        private readonly DataContext _db;

        public PlantRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Plant> CreatePlant(Plant Plant)
        {
            await _db.Plants.AddAsync(Plant);
            _db.SaveChanges();
            return Plant;
        }

        public async Task<bool> DeletePlant(int IdPlant)
        {
            var PlantAtDelete = await GetPlant(IdPlant);
            _db.Plants.Remove(PlantAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Plant> GetPlant(int IdPlant)
        {
            return await _db.Plants.FirstOrDefaultAsync(cu => cu.IdPlant == IdPlant);
        }

        public async Task<List<Plant>> GetPlants()
        {
            return await _db.Plants.ToListAsync();
        }

        public async Task<Plant> UpdatePlant(Plant Plant)
        {
            _db.Plants.Update(Plant);
            await _db.SaveChangesAsync();
            return Plant;
        }
    }
}