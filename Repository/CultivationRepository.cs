using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface ICultivationRepository
    {
        Task<List<Cultivation>> GetCultivations();
        Task<Cultivation> GetCultivation(int IdCultivation);
        Task<Cultivation> CreateCultivation(DateTime DateCultivation, float Area, int IdFarm, int IdStateCultivation);
        Task<Cultivation> UpdateCultivation(Cultivation cultivation);
        Task<bool> DeleteCultivation(int IdCultivation);

    }

    public class CultivationRepository : ICultivationRepository
    {

        private readonly DataContext _db;

        public CultivationRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Cultivation> CreateCultivation(DateTime DateCultivation, float Area, int IdFarm, int IdStateCultivation)
        {
            var newCultivation = new Cultivation()
            {
                DateCultivation = DateCultivation,
                Area = Area,
                IdFarm = IdFarm,
                IdStateCultivation = IdStateCultivation
            };

            await _db.Cultivations.AddAsync(newCultivation);

            _db.SaveChanges();

            return newCultivation;
        }

        public async Task<List<Cultivation>> GetCultivations()
        {
            return await _db.Cultivations.ToListAsync();

        }

        public async Task<Cultivation> GetCultivation(int IdCultivation)
        {
            return await _db.Cultivations.FirstOrDefaultAsync(cu => cu.IdCultivation == IdCultivation);
        }



        public async Task<Cultivation> UpdateCultivation(Cultivation cultivation)
        {
            _db.Cultivations.Update(cultivation);
            await _db.SaveChangesAsync();
            return cultivation;
        }

        public async Task<bool> DeleteCultivation(int IdCultivation)
        {
            var cultivation = await GetCultivation(IdCultivation);
            _db.Cultivations.Remove(cultivation);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}