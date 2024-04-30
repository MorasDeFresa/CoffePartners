using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{

    public interface IPlayerService
    {
        Task<List<Player>> getPlayers();
        Task<Player> getPlayer(int IdPlayer);
        Task<Player> createPlayer(string EmailPlayer, string PasswordPlayer, string NicknamePlayer);
        Task<Player> updatePlayer(int IdPlayer, string? EmailPlayer = null, string? PasswordPlayer = null, string? NicknamePlayer = null);
        Task<bool> deletePlayer(int IdPlayer);

    }


    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _PlayerRepository;


        public PlayerService(IPlayerRepository PlayerRepository)
        {
            _PlayerRepository = PlayerRepository;
        }

        public async Task<Player> createPlayer(string EmailPlayer, string PasswordPlayer, string NicknamePlayer)
        {
            return await _PlayerRepository.CreatePlayer(EmailPlayer, PasswordPlayer, NicknamePlayer);
        }

        public async Task<bool> deletePlayer(int IdPlayer)
        {
            await _PlayerRepository.DeletePlayer(IdPlayer);
            return true;
        }

        public async Task<Player> getPlayer(int IdPlayer)
        {
            return await _PlayerRepository.GetPlayer(IdPlayer);
        }

        public async Task<List<Player>> getPlayers()
        {
            return await _PlayerRepository.GetPlayers();
        }


        public async Task<Player> updatePlayer(int IdPlayer, string? EmailPlayer = null, string? PasswordPlayer = null, string? NicknamePlayer = null)
        {
            Player Player = await getPlayer(IdPlayer);
            if (IdPlayer <= 0)
            {
                throw new ArgumentException("El Id debe ser número positivo");
            }
            if (Player == null)
            {
                return null;
            }

            if (EmailPlayer != null) Player.EmailPlayer = EmailPlayer;
            if (PasswordPlayer != null) Player.PasswordPlayer = PasswordPlayer;
            if (NicknamePlayer != null) Player.NicknamePlayer = NicknamePlayer;

            return await _PlayerRepository.UpdatePlayer(Player);

        }
    }

}