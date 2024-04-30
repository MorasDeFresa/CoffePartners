using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{

    public interface IMachineryService
    {
        Task<List<Machinery>> getMachinerys();
        Task<Machinery> getMachinery(int IdMachinery);
        Task<Machinery> createMachinery(string NameMachine, string DescriptionMachine, float PriceMachine);
        Task<Machinery> updateMachinery(int IdMachinery, string? NameMachine = null, string? DescriptionMachine = null, float? PriceMachine = null);
        Task<bool> deleteMachinery(int IdMachinery);

    }


    public class MachineryService : IMachineryService
    {
        private readonly IMachineryRepository _MachineryRepository;


        public MachineryService(IMachineryRepository MachineryRepository)
        {
            _MachineryRepository = MachineryRepository;
        }

        public async Task<Machinery> createMachinery(string NameMachine, string DescriptionMachine, float PriceMachine)
        {
            return await _MachineryRepository.CreateMachinery(NameMachine, DescriptionMachine, PriceMachine);
        }

        public async Task<bool> deleteMachinery(int IdMachinery)
        {
            await _MachineryRepository.DeleteMachinery(IdMachinery);
            return true;
        }

        public async Task<Machinery> getMachinery(int IdMachinery)
        {
            return await _MachineryRepository.GetMachinery(IdMachinery);
        }

        public async Task<List<Machinery>> getMachinerys()
        {
            return await _MachineryRepository.GetMachinerys();
        }


        public async Task<Machinery> updateMachinery(int IdMachinery, string? NameMachine = null, string? DescriptionMachine = null, float? PriceMachine = null)
        {
            Machinery Machinery = await getMachinery(IdMachinery);
            if (IdMachinery <= 0)
            {
                throw new ArgumentException("El Id debe ser número positivo");
            }
            if (Machinery == null)
            {
                return null;
            }

            if (NameMachine != null) Machinery.NameMachine = NameMachine;
            if (DescriptionMachine != null) Machinery.DescriptionMachine = DescriptionMachine;
            if (PriceMachine != null || PriceMachine != 0) Machinery.PriceMachine = (float)PriceMachine;

            return await _MachineryRepository.UpdateMachinery(Machinery);

        }
    }

}