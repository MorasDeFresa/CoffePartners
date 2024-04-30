using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface IStatesCultivationRepository
    {
        Task<List<StatesCultivation>> GetStatesCultivations();
        Task<StatesCultivation> GetStatesCultivation(int IdStatesCultivation);
        Task<StatesCultivation> CreateStatesCultivation(string NameStateCultivation);
        Task<StatesCultivation> UpdateStatesCultivation(StatesCultivation StatesCultivation);
        Task<bool> DeleteStatesCultivation(int IdStatesCultivation);

    }

    public class StatesCultivationRepository : IStatesCultivationRepository
    {

        private readonly DataContext _db;

        public StatesCultivationRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<StatesCultivation> CreateStatesCultivation(string NameStateCultivation)
        {
            var newStatesCultivation = new StatesCultivation()
            {
                NameStateCultivation = NameStateCultivation
            };

            await _db.StatesCultivations.AddAsync(newStatesCultivation);

            _db.SaveChanges();

            return newStatesCultivation;
        }

        public async Task<List<StatesCultivation>> GetStatesCultivations()
        {
            return await _db.StatesCultivations.ToListAsync();

        }

        public async Task<StatesCultivation> GetStatesCultivation(int IdStatesCultivation)
        {
            return await _db.StatesCultivations.FirstOrDefaultAsync(cu => cu.IdStatesCultivation == IdStatesCultivation);
        }



        public async Task<StatesCultivation> UpdateStatesCultivation(StatesCultivation StatesCultivation)
        {
            _db.StatesCultivations.Update(StatesCultivation);
            await _db.SaveChangesAsync();
            return StatesCultivation;
        }

        public async Task<bool> DeleteStatesCultivation(int IdStatesCultivation)
        {
            var StatesCultivation = await GetStatesCultivation(IdStatesCultivation);
            _db.StatesCultivations.Remove(StatesCultivation);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}