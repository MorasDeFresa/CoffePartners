using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{
    public interface IFarmService
    {
        Task<List<Farm>> getFarms();
        Task<Farm> getFarm(int IdFarm);
        Task<Farm> createFarm(string NameFarm, int IdPlayer, float SizeFarm);
        Task<Farm> updateFarm(int IdFarm, string? NameFarm = null, int? IdPlayer = null, float? SizeFarm = null);
        Task<bool> deleteFarm(int IdFarm);
    }

    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;

        public FarmService(IFarmRepository farmHarvestRepository)
        {
            _farmRepository = farmHarvestRepository;
        }

        public async Task<Farm> createFarm(string NameFarm, int IdPlayer, float SizeFarm)
        {
            return await _farmRepository.CreateFarm(NameFarm, IdPlayer, SizeFarm);
        }

        public async Task<bool> deleteFarm(int IdFarm)
        {
            await _farmRepository.DeleteFarm(IdFarm);
            return true;
        }

        public async Task<Farm> getFarm(int IdFarm)
        {
            return await _farmRepository.GetFarm(IdFarm);
        }

        public async Task<List<Farm>> getFarms()
        {
            return await _farmRepository.GetFarms();
        }

        public async Task<Farm> updateFarm(int IdFarm, string? NameFarm = null, int? IdPlayer = null, float? SizeFarm = null)
        {
            Farm farm = await getFarm(IdFarm);

            if (IdFarm <= 0)
            {
                throw new ArgumentException("El ID debes er un número positivo");
            }
            if (farm == null)
            {
                return null;
            }

            if (NameFarm != null) farm.NameFarm = NameFarm;

            if (IdPlayer != null || IdPlayer != 0) farm.IdPlayer = (int)IdPlayer;

            if (SizeFarm != null || SizeFarm != 0) farm.SizeFarm = (float)SizeFarm;

            return await _farmRepository.UpdateFarm(farm);

        }
    }
}