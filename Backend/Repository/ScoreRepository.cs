using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface IScoreRepository
    {
        Task<List<Score>> GetScores();
        Task<Score> GetScore(int IdScore);
        Task<Score> CreateScore(float Points, int IdLevel, int IdFarm);
        Task<Score> UpdateScore(Score Score);
        Task<bool> DeleteScore(int IdScore);
    }

    public class ScoreRepository : IScoreRepository
    {
        private readonly DataContext _db;

        public ScoreRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Score> CreateScore(float Points, int IdLevel, int IdFarm)
        {
            var newScore = new Score()
            {
                Points = Points,
                IdLevel = IdLevel,
                IdFarm = IdFarm
            };

            await _db.Scores.AddAsync(newScore);

            _db.SaveChanges();

            return newScore;
        }

        public async Task<List<Score>> GetScores()
        {
            return await _db.Scores.ToListAsync();
        }

        public async Task<Score> GetScore(int IdScore)
        {
            return await _db.Scores.FirstOrDefaultAsync(ch => ch.IdScore == IdScore);
        }


        public async Task<Score> UpdateScore(Score Score)
        {
            _db.Scores.Update(Score);
            await _db.SaveChangesAsync();
            return Score;
        }

        public async Task<bool> DeleteScore(int IdScore)
        {
            var cultivationHarvest = await GetScore(IdScore);

            _db.Scores.Remove(cultivationHarvest);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}