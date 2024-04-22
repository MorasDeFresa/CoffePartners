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
        ICollection<Cultivation> getCultivations();
        Cultivation getCultivation(int IdCultivation);
        public bool cultivationExists(int IdCultivation);
        bool createCultivation(Cultivation cultivation);
        bool updateCultivation(Cultivation cultivation);
        bool deleteCultivation(Cultivation cultivation);
        bool Save();

    }

    public class CultivationRepository : ICultivationRepository
    {

        private readonly DataContext _db;

        public CultivationRepository(DataContext db)
        {
            _db = db;
        }


        public bool createCultivation(Cultivation cultivation)
        {
            _db.Add(cultivation);
            return Save();
        }

        public bool deleteCultivation(Cultivation cultivation)
        {
            _db.Remove(cultivation);
            return Save();
        }

        public Cultivation getCultivation(int IdCultivation)
        {
            return _db.Cultivations.Where(c => c.IdCultivation == IdCultivation).FirstOrDefault();
        }

        public ICollection<Cultivation> getCultivations()
        {
            return _db.Cultivations.OrderBy(c => c.IdCultivation).ToList();
        }

        public bool cultivationExists(int IdCultivation){
            return _db.Cultivations.Any(c => c.IdCultivation == IdCultivation);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateCultivation(Cultivation cultivation)
        {
            _db.Update(cultivation);
            return Save();
        }

        
    }
}