using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{

    public interface IStatesCultivationService
    {
        Task<List<StatesCultivation>> getStatesCultivations();
        Task<StatesCultivation> getStatesCultivation(int IdStatesCultivation);
        Task<StatesCultivation> createStatesCultivation(string NameStateCultivation);
        Task<StatesCultivation> updateStatesCultivation(int IdStatesCultivation, string? NameStateCultivation = null);
        Task<bool> deleteStatesCultivation(int IdStatesCultivation);

    }


    public class StatesCultivationService : IStatesCultivationService
    {
        private readonly IStatesCultivationRepository _StatesCultivationRepository;


        public StatesCultivationService(IStatesCultivationRepository StatesCultivationRepository)
        {
            _StatesCultivationRepository = StatesCultivationRepository;
        }

        public async Task<StatesCultivation> createStatesCultivation(string NameStateCultivation)
        {
            return await _StatesCultivationRepository.CreateStatesCultivation(NameStateCultivation);
        }

        public async Task<bool> deleteStatesCultivation(int IdStatesCultivation)
        {
            await _StatesCultivationRepository.DeleteStatesCultivation(IdStatesCultivation);
            return true;
        }

        public async Task<StatesCultivation> getStatesCultivation(int IdStatesCultivation)
        {
            return await _StatesCultivationRepository.GetStatesCultivation(IdStatesCultivation);
        }

        public async Task<List<StatesCultivation>> getStatesCultivations()
        {
            return await _StatesCultivationRepository.GetStatesCultivations();
        }


        public async Task<StatesCultivation> updateStatesCultivation(int IdStatesCultivation, string? NameStateCultivation = null)
        {
            StatesCultivation StatesCultivation = await getStatesCultivation(IdStatesCultivation);
            if (IdStatesCultivation <= 0)
            {
                throw new ArgumentException("El Id debe ser número positivo");
            }
            if (StatesCultivation == null)
            {
                return null;
            }

            if (NameStateCultivation != null) StatesCultivation.NameStateCultivation = NameStateCultivation;

            return await _StatesCultivationRepository.UpdateStatesCultivation(StatesCultivation);

        }
    }

}