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
        Player GetPlayer(int IdPlayer);
        Player GetPlayer(string NicknamePlayer);
        bool PlayerExists(int IdPlayer);
        bool UpdatePlayer(Player player);
        bool CreatePlayer(Player player);
        bool DeletePlayer(Player player);
        bool Save();
    }
}