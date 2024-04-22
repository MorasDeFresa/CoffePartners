using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public interface IHarvestProcessRepository
    {
        ICollection<HarvestProcess> getHarvestProcesss();
        HarvestProcess getHarvestProcess(int IdHarvestProcess);
        bool HarvestProcessExists(int IdHarvestProcess);
        bool createHarvestProcess(HarvestProcess HarvestProcess);
        bool updateHarvestProcess(HarvestProcess HarvestProcess);
        bool deleteHarvestProcess(HarvestProcess HarvestProcess);
        bool Save();
    }

    public class HarvestProcessRepository : IHarvestProcessRepository
    {
        private readonly DataContext _db;

        public HarvestProcessRepository(DataContext db)
        {
            _db = db;
        }

        public bool createHarvestProcess(HarvestProcess HarvestProcess)
        {
            _db.Add(HarvestProcess);
            return Save();
        }

        public bool deleteHarvestProcess(HarvestProcess HarvestProcess)
        {
            _db.Remove(HarvestProcess);
            return Save();
        }

        public HarvestProcess getHarvestProcess(int IdHarvestProcess)
        {
            return _db.HarvestProcesss.Where(hap => hap.IdHarvestProcess == IdHarvestProcess).FirstOrDefault();
        }

        public ICollection<HarvestProcess> getHarvestProcesss()
        {
            return _db.HarvestProcesss.OrderBy(hap => hap.IdHarvestProcess).ToList();
        }

        public bool HarvestProcessExists(int IdHarvestProcess)
        {
            return _db.HarvestProcesss.Any(hap => hap.IdHarvestProcess == IdHarvestProcess);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateHarvestProcess(HarvestProcess HarvestProcess)
        {
            _db.Update(HarvestProcess);
            return Save();
        }
    }
}