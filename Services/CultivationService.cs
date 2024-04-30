using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{

    public interface ICultivationService
    {
        Task<List<Cultivation>> getCultivations();
        Task<Cultivation> getCultivation(int IdCultivation);
        Task<Cultivation> createCultivation(DateTime DateCultivation, float Area, int IdFarm, int IdStateCultivation);
        Task<Cultivation> updateCultivation(int IdCultivation, DateTime? DateCultivation = null, float? Area = null, int? IdFarm = null, int? IdStateCultivation = null);
        Task<bool> deleteCultivation(int IdCultivation);

    }


    public class CultivationService : ICultivationService
    {
        private readonly ICultivationRepository _cultivationRepository;


        public CultivationService(ICultivationRepository cultivationRepository)
        {
            _cultivationRepository = cultivationRepository;
        }

        public async Task<Cultivation> createCultivation(DateTime DateCultivation, float Area, int IdFarm, int IdStateCultivation)
        {
            return await _cultivationRepository.CreateCultivation(DateCultivation, Area, IdFarm, IdStateCultivation);
        }

        public async Task<bool> deleteCultivation(int IdCultivation)
        {
            await _cultivationRepository.DeleteCultivation(IdCultivation);
            return true;
        }

        public async Task<Cultivation> getCultivation(int IdCultivation)
        {
            return await _cultivationRepository.GetCultivation(IdCultivation);
        }

        public async Task<List<Cultivation>> getCultivations()
        {
            return await _cultivationRepository.GetCultivations();
        }


        public async Task<Cultivation> updateCultivation(int IdCultivation, DateTime? DateCultivation = null, float? Area = null, int? IdFarm = null, int? IdStateCultivation = null)
        {
            Cultivation cultivation = await getCultivation(IdCultivation);
            if (IdCultivation <= 0)
            {
                throw new ArgumentException("El Id debe ser número positivo");
            }
            if (cultivation == null)
            {
                return null;
            }

            if (DateCultivation != null) cultivation.DateCultivation = (DateTime)DateCultivation;

            if (Area != null) cultivation.Area = (float)Area;

            if (IdFarm != null) cultivation.IdFarm = (int)IdFarm;

            if (IdStateCultivation != null) cultivation.IdStateCultivation = (int)IdStateCultivation;

            return await _cultivationRepository.UpdateCultivation(cultivation);

        }
    }

}