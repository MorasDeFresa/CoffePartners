using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
     public interface IFarmRepository
    {
        ICollection<Farm> getFarms();
        Farm getFarm(int IdFarm);
        bool farmExists(int IdFarm);
        bool createFarm(Farm Farm);
        bool updateFarm(Farm Farm);
        bool deleteFarm(Farm Farm);
        bool Save();

    }

    public class FarmRepository : IFarmRepository
    {
        private readonly DataContext _db;

        public FarmRepository(DataContext db){
            _db = db;
        }

        public bool createFarm(Farm Farm)
        {
            _db.Add(Farm);
            return Save();
        }

        public bool deleteFarm(Farm Farm)
        {
            _db.Remove(Farm);
            return Save();
        }

        public Farm getFarm(int IdFarm)
        {
            return _db.Farms.Where(fa => fa.IdFarm == IdFarm).FirstOrDefault();
        }

        public ICollection<Farm> getFarms()
        {
            return _db.Farms.OrderBy(fa => fa.IdFarm).ToList();
        }

        public bool farmExists(int IdFarm)
        {
            return _db.Farms.Any(fa => fa.IdFarm == IdFarm);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateFarm(Farm Farm)
        {
            _db.Update(Farm);
            return Save();
        }
    }
}