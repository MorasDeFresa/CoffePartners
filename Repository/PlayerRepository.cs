using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Data;
using CoffePartners.Interfaces;
using CoffePartners.Models;

namespace CoffePartners.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DataContext _context;

        public PlayerRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public bool CreatePlayer(Player player)
        {
            _context.Add(player);
            return Save();
        }

        public bool DeletePlayer(Player player)
        {
            _context.Remove(player);
            return Save();
        }

        public Player GetPlayer(int IdPlayer)
        {
            return _context.Players.Where(p => p.IdPlayer == IdPlayer).FirstOrDefault();
        }

        public Player GetPlayer(string NicknamePlayer)
        {
            return _context.Players.Where(p => p.NicknamePlayer == NicknamePlayer).FirstOrDefault();
        }

        public ICollection<Player> GetPlayers()
        {
            return _context.Players.OrderBy(p => p.IdPlayer).ToList();
        }

        public bool PlayerExists(int IdPlayer)
        {
            return _context.Players.Any(p => p.IdPlayer == IdPlayer);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePlayer(Player player)
        {
            _context.Update(player);
            return Save();
        }
    }
}