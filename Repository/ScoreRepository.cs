using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public interface IScoreRepository
    {
        ICollection<Score> getScores();
        Score getScore(int IdScore);
        bool ScoreExists(int IdScore);
        bool createScore(Score Score);
        bool updateScore(Score Score);
        bool deleteScore(Score Score);
        bool Save();
    }

    public class ScoreRepository : IScoreRepository
    {
        private readonly DataContext _db;

        public ScoreRepository(DataContext db)
        {
            _db = db;
        }

        public bool createScore(Score Score)
        {
            _db.Add(Score);
            return Save();
        }

        public bool deleteScore(Score Score)
        {
            _db.Remove(Score);
            return Save();
        }

        public Score getScore(int IdScore)
        {
            return _db.Scores.Where(sc => sc.IdScore == IdScore).FirstOrDefault();
        }

        public ICollection<Score> getScores()
        {
            return _db.Scores.OrderBy(sc => sc.IdScore).ToList();
        }
        
        public bool ScoreExists(int IdScore)
        {
            return _db.Scores.Any(sc => sc.IdScore == IdScore);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool updateScore(Score Score)
        {
            _db.Update(Score);
            return Save();
        }
    }
}