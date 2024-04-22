using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public interface IHarvestRepository
    {
        ICollection<Harvest> getHarvests();
        Harvest getHarvest(int IdHarvest);
        bool HarvestExists(int IdHarvest);
        bool createHarvest(Harvest Harvest);
        bool updateHarvest(Harvest Harvest);
        bool deleteHarvest(Harvest Harvest);
        bool Save();
    }

    public class HarvestRepository : IHarvestRepository
    {
        private readonly DataContext _db;

        public HarvestRepository(DataContext db)
        {
            _db = db;
        }

        public bool createHarvest(Harvest Harvest)
        {
           _db.Add(Harvest);
            return Save();
        }

        public bool deleteHarvest(Harvest Harvest)
        {
           _db.Remove(Harvest);
            return Save();
        }

        public Harvest getHarvest(int IdHarvest)
        {
            return _db.Harvests.Where(ha => ha.IdHarvest == IdHarvest).FirstOrDefault();
        }

        public ICollection<Harvest> getHarvests()
        {
             return _db.Harvests.OrderBy(ha => ha.IdHarvest).ToList();
        }

        public bool HarvestExists(int IdHarvest)
        {
            return _db.Harvests.Any(ha => ha.IdHarvest == IdHarvest);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateHarvest(Harvest Harvest)
        {
            _db.Update(Harvest);
            return Save();
        }
    }
}