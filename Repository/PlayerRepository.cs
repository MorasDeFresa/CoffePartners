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

        public ICollection<Player> GetPlayers()
        {
            return _context.Players.OrderBy(p => p.IdPlayer).ToList();
        }
    }
}