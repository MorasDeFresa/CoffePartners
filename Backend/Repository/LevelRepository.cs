using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface ILevelRepository
    {
        Task<List<Level>> GetLevels();
        Task<Level> GetLevel(int IdLevel);
        Task<Level> CreateLevel(float Duration, string Description);
        Task<Level> UpdateLevel(Level Level);
        Task<bool> DeleteLevel(int IdLevel);

    }

    public class LevelRepository : ILevelRepository
    {

        private readonly DataContext _db;

        public LevelRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Level> CreateLevel(float Duration, string Description)
        {
            var newLevel = new Level()
            {
                Duration = Duration,
                Description = Description
            };

            await _db.Levels.AddAsync(newLevel);

            _db.SaveChanges();

            return newLevel;
        }

        public async Task<List<Level>> GetLevels()
        {
            return await _db.Levels.ToListAsync();

        }

        public async Task<Level> GetLevel(int IdLevel)
        {
            return await _db.Levels.FirstOrDefaultAsync(cu => cu.IdLevel == IdLevel);
        }



        public async Task<Level> UpdateLevel(Level Level)
        {
            _db.Levels.Update(Level);
            await _db.SaveChangesAsync();
            return Level;
        }

        public async Task<bool> DeleteLevel(int IdLevel)
        {
            var Level = await GetLevel(IdLevel);
            _db.Levels.Remove(Level);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}