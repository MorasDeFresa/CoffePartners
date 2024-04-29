using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{
    public interface ICultivationHarvestService
    {
        Task<List<CultivationHarvest>> getCultivationHarvests();
        Task<CultivationHarvest> getCultivationHarvest(int IdCultivationHarvest);
        Task<CultivationHarvest> createCultivationHarvest(Cultivation IdCultivation, Harvest IdHarvest, float WeightHarvest);
        Task<CultivationHarvest> updateCultivationHarvest(int IdCultivationHarvest, Cultivation? IdCultivation = null, Harvest? IdHarvest = null, float? WeightHarvest = null);
        Task<bool> deleteCultivationHarvest(int IdCultivationHarvest);
    }

    public class CultivationHarvestService : ICultivationHarvestService
    {
        private readonly ICultivationHarvestHarvestRepository _cultivationHarvestRepository;

        public CultivationHarvestService(ICultivationHarvestHarvestRepository cultivationHarvestHarvestRepository)
        {
            _cultivationHarvestRepository = cultivationHarvestHarvestRepository;
        }

        public async Task<CultivationHarvest> createCultivationHarvest(Cultivation IdCultivation, Harvest IdHarvest, float WeightHarvest)
        {
            return await _cultivationHarvestRepository.CreateCultivationHarvest(IdCultivation, IdHarvest, WeightHarvest);
        }

        public async Task<bool> deleteCultivationHarvest(int IdCultivationHarvest)
        {
            await _cultivationHarvestRepository.DeleteCultivationHarvest(IdCultivationHarvest);
            return true;
        }

        public async Task<CultivationHarvest> getCultivationHarvest(int IdCultivationHarvest)
        {
            return await _cultivationHarvestRepository.GetCultivationHarvest(IdCultivationHarvest);
        }

        public async Task<List<CultivationHarvest>> getCultivationHarvests()
        {
            return await _cultivationHarvestRepository.GetCultivationHarvests();
        }

        public async Task<CultivationHarvest> updateCultivationHarvest(int IdCultivationHarvest, Cultivation? IdCultivation = null, Harvest? IdHarvest = null, float? WeightHarvest = null)
        {
            CultivationHarvest cultivationHarvest = await getCultivationHarvest(IdCultivationHarvest);

            if (IdCultivationHarvest <= 0)
            {
                throw new ArgumentException("El ID debes er un número positivo");
            }
            if (cultivationHarvest == null)
            {
                return null;
            }

            if (IdCultivation != null) cultivationHarvest.IdCultivation = IdCultivation;

            if (IdHarvest != null) cultivationHarvest.IdHarvest = IdHarvest;

            if (WeightHarvest != null) cultivationHarvest.WeightHarvest = (float)WeightHarvest;

            return await _cultivationHarvestRepository.UpdateCultivationHarvest(cultivationHarvest);

        }
    }
}