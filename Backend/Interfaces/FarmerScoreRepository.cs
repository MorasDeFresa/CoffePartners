using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IFarmerScoreRepository
    {
        Task<List<FarmerScore>> GetFarmerScores();
        Task<FarmerScore> GetFarmerScore(int IdFarmerScore);
        Task<FarmerScore> CreateFarmerScore(FarmerScore FarmerScore);
        Task<FarmerScore> UpdateFarmerScore(FarmerScore FarmerScore);
        Task<bool> DeleteFarmerScore(int IdFarmerScore);
    }

    public class FarmerScoreRepository : IFarmerScoreRepository
    {
        private readonly DataContext _db;

        public FarmerScoreRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<FarmerScore> CreateFarmerScore(FarmerScore FarmerScore)
        {
            await _db.FarmerScores.AddAsync(FarmerScore);
            _db.SaveChanges();
            return FarmerScore;
        }

        public async Task<bool> DeleteFarmerScore(int IdFarmerScore)
        {
            var FarmerScoreAtDelete = await GetFarmerScore(IdFarmerScore);
            _db.FarmerScores.Remove(FarmerScoreAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<FarmerScore> GetFarmerScore(int IdFarmerScore)
        {
            return await _db.FarmerScores.FirstOrDefaultAsync(cu => cu.IdFarmerScore == IdFarmerScore);
        }

        public async Task<List<FarmerScore>> GetFarmerScores()
        {
            return await _db.FarmerScores.ToListAsync();
        }

        public async Task<FarmerScore> UpdateFarmerScore(FarmerScore FarmerScore)
        {
            _db.FarmerScores.Update(FarmerScore);
            await _db.SaveChangesAsync();
            return FarmerScore;
        }
    }
}