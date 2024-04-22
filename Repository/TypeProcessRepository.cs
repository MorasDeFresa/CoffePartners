using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public interface ITypeProcessRepository
    {
        ICollection<TypeProcess> getTypeProcesss();
        TypeProcess getTypeProcess(int IdTypeProcess);
        bool TypeProcessExists(int IdTypeProcess);
        bool createTypeProcess(TypeProcess TypeProcess);
        bool updateTypeProcess(TypeProcess TypeProcess);
        bool deleteTypeProcess(TypeProcess TypeProcess);
        bool Save();
    }

    public class TypeProcessRepository : ITypeProcessRepository
    {
        private readonly DataContext _db;

        public TypeProcessRepository(DataContext db)
        {
            _db = db;
        }

        public bool createTypeProcess(TypeProcess TypeProcess)
        {
            _db.Add(TypeProcess);
            return Save();
        }

        public bool deleteTypeProcess(TypeProcess TypeProcess)
        {
            _db.Remove(TypeProcess);
            return Save();
        }

        public TypeProcess getTypeProcess(int IdTypeProcess)
        {
            return _db.TypeProcesss.Where(ty => ty.IdTypeProcess == IdTypeProcess).FirstOrDefault();
        }

        public ICollection<TypeProcess> getTypeProcesss()
        {
            return _db.TypeProcesss.OrderBy(ty => ty.IdTypeProcess).ToList();
        }

        public bool TypeProcessExists(int IdTypeProcess)
        {
            return _db.TypeProcesss.Any(ty => ty.IdTypeProcess == IdTypeProcess);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        
        public bool updateTypeProcess(TypeProcess TypeProcess)
        {
            _db.Update(TypeProcess);
            return Save();
        }
    }
}