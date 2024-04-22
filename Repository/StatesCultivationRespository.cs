using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public interface IStatesCultivationRepository
    {
        ICollection<StatesCultivation> getStatesCultivations();
        StatesCultivation getStatesCultivation(int IdStateCultivation);
        bool StatesCultivationExists(int IdStateCultivation);
        bool createStatesCultivation(StatesCultivation StatesCultivation);
        bool updateStatesCultivation(StatesCultivation StatesCultivation);
        bool deleteStatesCultivation(StatesCultivation StatesCultivation);
        bool Save();

    }

    public class StatesCultivationRepository : IStatesCultivationRepository
    {
        private readonly DataContext _db;

        public StatesCultivationRepository(DataContext db)
        {
            _db = db;
        }

        public bool createStatesCultivation(StatesCultivation StatesCultivation)
        {
            _db.Add(StatesCultivation);
            return Save();
        }

        public bool deleteStatesCultivation(StatesCultivation StatesCultivation)
        {
            _db.Remove(StatesCultivation);
            return Save();
        }

        public StatesCultivation getStatesCultivation(int IdStateCultivation)
        {
            return _db.StatesCultivations.Where(st => st.IdStateCultivation == IdStateCultivation).FirstOrDefault();
        }

        public ICollection<StatesCultivation> getStatesCultivations()
        {
            return _db.StatesCultivations.OrderBy(st => st.IdStateCultivation).ToList();
        }

        public bool StatesCultivationExists(int IdStateCultivation)
        {
            return _db.StatesCultivations.Any(st => st.IdStateCultivation == IdStateCultivation);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateStatesCultivation(StatesCultivation StatesCultivation)
        {
            _db.Update(StatesCultivation);
            return Save();
        }
        
    }
  
}