using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IScoreRepository
    {
        Task<List<Score>> GetScores();
        Task<Score> GetScore(int IdScore);
        Task<int> GetIdScoreByPoint(float PointScore);
        Task<Score> CreateScore(Score Score);
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

        public async Task<Score> CreateScore(Score Score)
        {
            await _db.Scores.AddAsync(Score);
            _db.SaveChanges();
            return Score;
        }

        public async Task<bool> DeleteScore(int IdScore)
        {
            var scoreAtDelete = await GetScore(IdScore);
            _db.Scores.Remove(scoreAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetIdScoreByPoint(float PointScore)
        {
            var score = await _db.Scores.FirstOrDefaultAsync(score => score.MinimunPoints <= PointScore && PointScore <= score.MaximunPoints);
            if (score == null) throw new Exception("Puntaje fuera de limites");
            return score.IdScore;
        }

        public async Task<Score> GetScore(int IdScore)
        {
            return await _db.Scores.FirstOrDefaultAsync(cu => cu.IdScore == IdScore);
        }

        public async Task<List<Score>> GetScores()
        {
            return await _db.Scores.ToListAsync();
        }

        public async Task<Score> UpdateScore(Score Score)
        {
            _db.Scores.Update(Score);
            await _db.SaveChangesAsync();
            return Score;
        }
    }
}