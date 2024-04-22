using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public interface IMachineryRepository
    {
        ICollection<Machinery> getMachinerys();
        Machinery getMachinery(int IdMachinery);
        bool MachineryExists(int IdMachinery);
        bool createMachinery(Machinery Machinery);
        bool updateMachinery(Machinery Machinery);
        bool deleteMachinery(Machinery Machinery);
        bool Save();
    }

    public class MachineryRepository : IMachineryRepository
    {
        private readonly DataContext _db;

        public MachineryRepository(DataContext db){
            _db = db;
        }

        public bool createMachinery(Machinery Machinery)
        {
            _db.Add(Machinery);
            return Save();
        }

        public bool deleteMachinery(Machinery Machinery)
        {
            _db.Remove(Machinery);
            return Save();
        }

        public Machinery getMachinery(int IdMachinery)
        {
            return _db.Machinerys.Where(ma => ma.IdMachinery == IdMachinery).FirstOrDefault();
        }

        public ICollection<Machinery> getMachinerys()
        {
            return _db.Machinerys.OrderBy(ma => ma.IdMachinery).ToList();
        }

        public bool MachineryExists(int IdMachinery)
        {
            return _db.Machinerys.Any(ma => ma.IdMachinery == IdMachinery);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateMachinery(Machinery Machinery)
        {
            _db.Update(Machinery);
            return Save();
        }
    }

}