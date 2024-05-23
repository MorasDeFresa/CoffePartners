using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface ITypeQualityRepository
    {
        Task<List<TypeQuality>> GetTypeQualitys();
        Task<TypeQuality> GetTypeQuality(int IdTypeQuality);
        Task<TypeQuality> CreateTypeQuality(TypeQuality TypeQuality);
        Task<TypeQuality> UpdateTypeQuality(TypeQuality TypeQuality);
        Task<bool> DeleteTypeQuality(int IdTypeQuality);
    }

    public class TypeQualityRepository : ITypeQualityRepository
    {
        private readonly DataContext _db;

        public TypeQualityRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<TypeQuality> CreateTypeQuality(TypeQuality TypeQuality)
        {
            await _db.TypeQualitys.AddAsync(TypeQuality);
            _db.SaveChanges();
            return TypeQuality;
        }

        public async Task<bool> DeleteTypeQuality(int IdTypeQuality)
        {
            var TypeQualityAtDelete = await GetTypeQuality(IdTypeQuality);
            _db.TypeQualitys.Remove(TypeQualityAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<TypeQuality> GetTypeQuality(int IdTypeQuality)
        {
            return await _db.TypeQualitys.FirstOrDefaultAsync(cu => cu.IdTypeQuality == IdTypeQuality);
        }

        public async Task<List<TypeQuality>> GetTypeQualitys()
        {
            return await _db.TypeQualitys.ToListAsync();
        }

        public async Task<TypeQuality> UpdateTypeQuality(TypeQuality TypeQuality)
        {
            _db.TypeQualitys.Update(TypeQuality);
            await _db.SaveChangesAsync();
            return TypeQuality;
        }
    }
}