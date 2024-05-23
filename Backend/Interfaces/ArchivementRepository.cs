using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Interfaces
{
    public interface IArchivementRepository
    {
        Task<List<Archivement>> GetArchivements();
        Task<Archivement> GetArchivement(int IdArchivement);
        Task<Archivement> CreateArchivement(Archivement Archivement);
        Task<Archivement> UpdateArchivement(Archivement Archivement);
        Task<bool> DeleteArchivement(int IdArchivement);
    }

    public class ArchivementRepository : IArchivementRepository
    {
        private readonly DataContext _db;

        public ArchivementRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Archivement> CreateArchivement(Archivement Archivement)
        {
            await _db.Archivements.AddAsync(Archivement);
            _db.SaveChanges();
            return Archivement;
        }

        public async Task<bool> DeleteArchivement(int IdArchivement)
        {
            var ArchivementAtDelete = await GetArchivement(IdArchivement);
            _db.Archivements.Remove(ArchivementAtDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Archivement> GetArchivement(int IdArchivement)
        {
            return await _db.Archivements.FirstOrDefaultAsync(cu => cu.IdArchivement == IdArchivement);
        }

        public async Task<List<Archivement>> GetArchivements()
        {
            return await _db.Archivements.ToListAsync();
        }

        public async Task<Archivement> UpdateArchivement(Archivement Archivement)
        {
            _db.Archivements.Update(Archivement);
            await _db.SaveChangesAsync();
            return Archivement;
        }
    }
}