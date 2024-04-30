using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffePartners.Repository
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayers();
        Task<Player> GetPlayer(int IdPlayer);
        Task<Player> CreatePlayer(string EmailPlayer, string PasswordPlayer, string NicknamePlayer);
        Task<Player> UpdatePlayer(Player Player);
        Task<bool> DeletePlayer(int IdPlayer);

    }

    public class PlayerRepository : IPlayerRepository
    {

        private readonly DataContext _db;

        public PlayerRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Player> CreatePlayer(string EmailPlayer, string PasswordPlayer, string NicknamePlayer)
        {
            var newPlayer = new Player()
            {
                EmailPlayer = EmailPlayer,
                PasswordPlayer = PasswordPlayer,
                NicknamePlayer = NicknamePlayer
            };

            await _db.Players.AddAsync(newPlayer);

            _db.SaveChanges();

            return newPlayer;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _db.Players.ToListAsync();

        }

        public async Task<Player> GetPlayer(int IdPlayer)
        {
            return await _db.Players.FirstOrDefaultAsync(cu => cu.IdPlayer == IdPlayer);
        }



        public async Task<Player> UpdatePlayer(Player Player)
        {
            _db.Players.Update(Player);
            await _db.SaveChangesAsync();
            return Player;
        }

        public async Task<bool> DeletePlayer(int IdPlayer)
        {
            var Player = await GetPlayer(IdPlayer);
            _db.Players.Remove(Player);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}