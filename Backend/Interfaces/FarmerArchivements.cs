using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IFarmerArchivementsRepository
    {
        Task<List<FarmerArchivements>> GetFarmerArchivements();
        Task<FarmerArchivements> GetFarmerArchivements(int IdFarmerArchivements);
        Task<FarmerArchivements> CreateFarmerArchivements(FarmerArchivements FarmerArchivements);
        Task<FarmerArchivements> UpdateFarmerArchivements(FarmerArchivements FarmerArchivements);
        Task<bool> DeleteFarmerArchivements(int IdFarmerArchivements);
    }

    public class FarmerArchivementsRepository : IFarmerArchivementsRepository
    {
        private readonly DataContext _db;

        public FarmerArchivementsRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<FarmerArchivements> CreateFarmerArchivements(FarmerArchivements FarmerArchivements)
        {
            await _db.FarmerArchivements.AddAsync(FarmerArchivements);
            _db.SaveChanges();
            return FarmerArchivements;
        }

        public async Task<bool> DeleteFarmerArchivements(int IdFarmerArchivements)
        {
            var FarmerArchivementsAtDelete = await GetFarmerArchivements(IdFarmerArchivements);
            _db.FarmerArchivements.Remove(FarmerArchivementsAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<FarmerArchivements> GetFarmerArchivements(int IdFarmerArchivements)
        {
            return await _db.FarmerArchivements.FirstOrDefaultAsync(cu => cu.IdFarmerArchivement == IdFarmerArchivements);
        }

        public async Task<List<FarmerArchivements>> GetFarmerArchivements()
        {
            return await _db.FarmerArchivements.ToListAsync();
        }

        public async Task<FarmerArchivements> UpdateFarmerArchivements(FarmerArchivements FarmerArchivements)
        {
            _db.FarmerArchivements.Update(FarmerArchivements);
            await _db.SaveChangesAsync();
            return FarmerArchivements;
        }
    }
}