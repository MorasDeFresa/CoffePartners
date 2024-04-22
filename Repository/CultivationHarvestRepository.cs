using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CoffePartners.Repository
{
    public interface ICultivationHarvestRepository
    {
        ICollection<CultivationHarvest> getCultivationHarvests();
        CultivationHarvest getCultivationHarvest(int IdCultivationHarvest);
        public bool cultivationHarvestExists(int IdCultivationHarvest);
        bool createCultivationHarvest(CultivationHarvest cultivationHarvest);
        bool updateCultivationHarvest(CultivationHarvest cultivationHarvest);
        bool deleteCultivationHarvest(CultivationHarvest cultivationHarvest);
        bool Save();
    }

    public class CultivationHarvestRepository : ICultivationHarvestRepository
    {
        private readonly DataContext _db;

        public CultivationHarvestRepository(DataContext db)
        {
            _db = db;
        }

        public bool createCultivationHarvest(CultivationHarvest cultivationHarvest)
        {
            _db.Add(cultivationHarvest);
            return Save();
        }

        public bool deleteCultivationHarvest(CultivationHarvest cultivationHarvest)
        {
            _db.Remove(cultivationHarvest);
            return Save();
        }

        public CultivationHarvest getCultivationHarvest(int IdCultivationHarvest)
        {
            return _db.CultivationHarvests.Where(cu => cu.IdCultivationHarvest == IdCultivationHarvest).FirstOrDefault();
        }

        public ICollection<CultivationHarvest> getCultivationHarvests()
        {
            return _db.CultivationHarvests.OrderBy(cu => cu.IdCultivationHarvest).ToList();
        }

        public bool cultivationHarvestExists(int IdCultivationHarvest)
        {
            return _db.CultivationHarvests.Any(cu => cu.IdCultivationHarvest == IdCultivationHarvest);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateCultivationHarvest(CultivationHarvest cultivationHarvest)
        {
            _db.Update(cultivationHarvest);
            return Save();
        }

    }
}