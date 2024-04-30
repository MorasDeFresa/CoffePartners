using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface IMachineryRepository
    {
        Task<List<Machinery>> GetMachinerys();
        Task<Machinery> GetMachinery(int IdMachinery);
        Task<Machinery> CreateMachinery(string NameMachine, string DescriptionMachine, float PriceMachine);
        Task<Machinery> UpdateMachinery(Machinery Machinery);
        Task<bool> DeleteMachinery(int IdMachinery);

    }

    public class MachineryRepository : IMachineryRepository
    {

        private readonly DataContext _db;

        public MachineryRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Machinery> CreateMachinery(string NameMachine, string DescriptionMachine, float PriceMachine)
        {
            var newMachinery = new Machinery()
            {
                NameMachine = NameMachine,
                DescriptionMachine = DescriptionMachine,
                PriceMachine = PriceMachine
            };

            await _db.Machinerys.AddAsync(newMachinery);

            _db.SaveChanges();

            return newMachinery;
        }

        public async Task<List<Machinery>> GetMachinerys()
        {
            return await _db.Machinerys.ToListAsync();

        }

        public async Task<Machinery> GetMachinery(int IdMachinery)
        {
            return await _db.Machinerys.FirstOrDefaultAsync(cu => cu.IdMachinery == IdMachinery);
        }



        public async Task<Machinery> UpdateMachinery(Machinery Machinery)
        {
            _db.Machinerys.Update(Machinery);
            await _db.SaveChangesAsync();
            return Machinery;
        }

        public async Task<bool> DeleteMachinery(int IdMachinery)
        {
            var Machinery = await GetMachinery(IdMachinery);
            _db.Machinerys.Remove(Machinery);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}