using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;

namespace CoffePartners.Interfaces
{
    public interface IPlayerRepository
    {
        ICollection<Player> GetPlayers();
    }
}