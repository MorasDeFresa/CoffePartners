using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public interface ILevelRepository
    {
        ICollection<Level> getLevels();
        Level getLevel(int IdLevel);
        bool LevelExists(int IdLevel);
        bool createLevel(Level Level);
        bool updateLevel(Level Level);
        bool deleteLevel(Level Level);
        bool Save();
    }

    public class LevelRepository : ILevelRepository
    {
        private readonly DataContext _db;

        public LevelRepository(DataContext db)
        {
            _db = db;
        }

        public bool createLevel(Level Level)
        {
            _db.Add(Level);
            return Save();
        }

        public bool deleteLevel(Level Level)
        {
            _db.Remove(Level);
            return Save();
        }

        public Level getLevel(int IdLevel)
        {
            return _db.Levels.Where(le => le.IdLevel == IdLevel).FirstOrDefault();
        }

        public ICollection<Level> getLevels()
        {
            return _db.Levels.OrderBy(le => le.IdLevel).ToList();
        }

        public bool LevelExists(int IdLevel)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateLevel(Level Level)
        {
             _db.Update(Level);
            return Save();
        }
    }
}