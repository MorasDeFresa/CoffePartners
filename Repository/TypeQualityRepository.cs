using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public interface ITypeQualityRepository
    {
        ICollection<TypeQuality> getTypeQualitys();
        TypeQuality getTypeQuality(int IdTypeQuality);
        bool TypeQualityExists(int IdTypeQuality);
        bool createTypeQuality(TypeQuality TypeQuality);
        bool updateTypeQuality(TypeQuality TypeQuality);
        bool deleteTypeQuality(TypeQuality TypeQuality);
        bool Save();
    }

    public class TypeQualityRepository : ITypeQualityRepository
    {
        private readonly DataContext _db;

        public TypeQualityRepository(DataContext db){
            _db = db;
        }

        public bool createTypeQuality(TypeQuality TypeQuality)
        {
            _db.Add(TypeQuality);
            return Save();
        }

        public bool deleteTypeQuality(TypeQuality TypeQuality)
        {
            _db.Remove(TypeQuality);
            return Save();
        }

        public TypeQuality getTypeQuality(int IdTypeQuality)
        {
             return _db.TypeQualitys.Where(tyq => tyq.IdTypeQuality == IdTypeQuality).FirstOrDefault();
        }

        public ICollection<TypeQuality> getTypeQualitys()
        {
            return _db.TypeQualitys.OrderBy(tyq => tyq.IdTypeQuality).ToList();
        }

        public bool TypeQualityExists(int IdTypeQuality)
        {
            return _db.TypeQualitys.Any(tyq => tyq.IdTypeQuality == IdTypeQuality);
        }

        public bool Save()
        {
           var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        

        public bool updateTypeQuality(TypeQuality TypeQuality)
        {
            _db.Update(TypeQuality);
            return Save();
        }
        
    }
}