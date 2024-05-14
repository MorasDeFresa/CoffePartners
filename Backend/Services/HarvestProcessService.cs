using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{
    public interface IHarvestProcessService
    {
        Task<List<HarvestProcess>> getHarvestProcesss();
        Task<HarvestProcess> getHarvestProcess(int IdTypeProcessProcess);
        Task<HarvestProcess> createHarvestProcess(int IdCultivationHarvest, int IdTypeProcess, float HeightWastedGrain);
        Task<HarvestProcess> updateHarvestProcess(int IdTypeProcessProcess, int? IdCultivationHarvest = null, int? IdTypeProcess = null, float? HeightWastedGrain = null);
        Task<bool> deleteHarvestProcess(int IdTypeProcessProcess);
    }

    public class HarvestProcessService : IHarvestProcessService
    {
        private readonly IHarvestProcessRepository _cultivationHarvestRepository;

        public HarvestProcessService(IHarvestProcessRepository cultivationHarvestHarvestRepository)
        {
            _cultivationHarvestRepository = cultivationHarvestHarvestRepository;
        }

        public async Task<HarvestProcess> createHarvestProcess(int IdCultivationHarvest, int IdTypeProcess, float HeightWastedGrain)
        {
            return await _cultivationHarvestRepository.CreateHarvestProcess(IdCultivationHarvest, IdTypeProcess, HeightWastedGrain);
        }

        public async Task<bool> deleteHarvestProcess(int IdTypeProcessProcess)
        {
            await _cultivationHarvestRepository.DeleteHarvestProcess(IdTypeProcessProcess);
            return true;
        }

        public async Task<HarvestProcess> getHarvestProcess(int IdTypeProcessProcess)
        {
            return await _cultivationHarvestRepository.GetHarvestProcess(IdTypeProcessProcess);
        }

        public async Task<List<HarvestProcess>> getHarvestProcesss()
        {
            return await _cultivationHarvestRepository.GetHarvestProcesss();
        }

        public async Task<HarvestProcess> updateHarvestProcess(int IdTypeProcessProcess, int? IdCultivationHarvest = null, int? IdTypeProcess = null, float? HeightWastedGrain = null)
        {
            HarvestProcess cultivationHarvest = await getHarvestProcess(IdTypeProcessProcess);

            if (IdTypeProcessProcess <= 0)
            {
                throw new ArgumentException("El ID debes er un número positivo");
            }
            if (cultivationHarvest == null)
            {
                return null;
            }

            if (IdCultivationHarvest != null || IdCultivationHarvest != 0) cultivationHarvest.IdCultivationHarvest = (int)IdCultivationHarvest;

            if (IdTypeProcess != null || IdTypeProcess != 0) cultivationHarvest.IdTypeProcess = (int)IdTypeProcess;

            if (HeightWastedGrain != null || HeightWastedGrain != 0) cultivationHarvest.HeightWastedGrain = (float)HeightWastedGrain;

            return await _cultivationHarvestRepository.UpdateHarvestProcess(cultivationHarvest);

        }
    }
}