using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{

    public interface ITypeQualityService
    {
        Task<List<TypeQuality>> getTypeQualitys();
        Task<TypeQuality> getTypeQuality(int IdTypeQuality);
        Task<TypeQuality> createTypeQuality(string NameQuality, int PriceByGr);
        Task<TypeQuality> updateTypeQuality(int IdTypeQuality, string? NameQuality = null, int? PriceByGr = null);
        Task<bool> deleteTypeQuality(int IdTypeQuality);

    }


    public class TypeQualityService : ITypeQualityService
    {
        private readonly ITypeQualityRepository _TypeQualityRepository;


        public TypeQualityService(ITypeQualityRepository TypeQualityRepository)
        {
            _TypeQualityRepository = TypeQualityRepository;
        }

        public async Task<TypeQuality> createTypeQuality(string NameQuality, int PriceByGr)
        {
            return await _TypeQualityRepository.CreateTypeQuality(NameQuality, PriceByGr);
        }

        public async Task<bool> deleteTypeQuality(int IdTypeQuality)
        {
            await _TypeQualityRepository.DeleteTypeQuality(IdTypeQuality);
            return true;
        }

        public async Task<TypeQuality> getTypeQuality(int IdTypeQuality)
        {
            return await _TypeQualityRepository.GetTypeQuality(IdTypeQuality);
        }

        public async Task<List<TypeQuality>> getTypeQualitys()
        {
            return await _TypeQualityRepository.GetTypeQualitys();
        }


        public async Task<TypeQuality> updateTypeQuality(int IdTypeQuality, string? NameQuality = null, int? PriceByGr = null)
        {
            TypeQuality TypeQuality = await getTypeQuality(IdTypeQuality);
            if (IdTypeQuality <= 0)
            {
                throw new ArgumentException("El Id debe ser número positivo");
            }
            if (TypeQuality == null)
            {
                return null;
            }

            if (NameQuality != null) TypeQuality.NameQuality = NameQuality;

            if (PriceByGr != null) TypeQuality.PriceByGr = (int)PriceByGr;

            return await _TypeQualityRepository.UpdateTypeQuality(TypeQuality);

        }
    }

}