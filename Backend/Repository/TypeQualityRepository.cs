using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface ITypeQualityRepository
    {
        Task<List<TypeQuality>> GetTypeQualitys();
        Task<TypeQuality> GetTypeQuality(int IdTypeQuality);
        Task<TypeQuality> CreateTypeQuality(string NameQuality, int PriceByGr);
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

        public async Task<TypeQuality> CreateTypeQuality(string NameQuality, int PriceByGr)
        {
            var newTypeQuality = new TypeQuality()
            {
                NameQuality = NameQuality,
                PriceByGr = PriceByGr
            };

            await _db.TypeQualitys.AddAsync(newTypeQuality);

            _db.SaveChanges();

            return newTypeQuality;
        }

        public async Task<List<TypeQuality>> GetTypeQualitys()
        {
            return await _db.TypeQualitys.ToListAsync();

        }

        public async Task<TypeQuality> GetTypeQuality(int IdTypeQuality)
        {
            return await _db.TypeQualitys.FirstOrDefaultAsync(cu => cu.IdTypeQuality == IdTypeQuality);
        }



        public async Task<TypeQuality> UpdateTypeQuality(TypeQuality TypeQuality)
        {
            _db.TypeQualitys.Update(TypeQuality);
            await _db.SaveChangesAsync();
            return TypeQuality;
        }

        public async Task<bool> DeleteTypeQuality(int IdTypeQuality)
        {
            var TypeQuality = await GetTypeQuality(IdTypeQuality);
            _db.TypeQualitys.Remove(TypeQuality);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}