using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{
    public interface IHarvestService
    {
        Task<List<Harvest>> getHarvests();
        Task<Harvest> getHarvest(int IdHarvest);
        Task<Harvest> createHarvest(DateTime DateHarvest, int IdTypeQuality);
        Task<Harvest> updateHarvest(int IdHarvest, DateTime? DateHarvest = null, int? IdTypeQuality = null);
        Task<bool> deleteHarvest(int IdHarvest);
    }

    public class HarvestService : IHarvestService
    {
        private readonly IHarvestRepository _cultivationHarvestRepository;

        public HarvestService(IHarvestRepository cultivationHarvestHarvestRepository)
        {
            _cultivationHarvestRepository = cultivationHarvestHarvestRepository;
        }

        public async Task<Harvest> createHarvest(DateTime DateHarvest, int IdTypeQuality)
        {
            return await _cultivationHarvestRepository.CreateHarvest(DateHarvest, IdTypeQuality);
        }

        public async Task<bool> deleteHarvest(int IdHarvest)
        {
            await _cultivationHarvestRepository.DeleteHarvest(IdHarvest);
            return true;
        }

        public async Task<Harvest> getHarvest(int IdHarvest)
        {
            return await _cultivationHarvestRepository.GetHarvest(IdHarvest);
        }

        public async Task<List<Harvest>> getHarvests()
        {
            return await _cultivationHarvestRepository.GetHarvests();
        }

        public async Task<Harvest> updateHarvest(int IdHarvest, DateTime? DateHarvest = null, int? IdTypeQuality = null)
        {
            Harvest cultivationHarvest = await getHarvest(IdHarvest);

            if (IdHarvest <= 0)
            {
                throw new ArgumentException("El ID debes er un número positivo");
            }
            if (cultivationHarvest == null)
            {
                return null;
            }

            if (DateHarvest != null) cultivationHarvest.DateHarvest = (DateTime)DateHarvest;

            if (IdTypeQuality != null || IdTypeQuality != 0) cultivationHarvest.IdTypeQuality = (int)IdTypeQuality;

            return await _cultivationHarvestRepository.UpdateHarvest(cultivationHarvest);

        }
    }
}