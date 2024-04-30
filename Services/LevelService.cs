using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{

    public interface ILevelService
    {
        Task<List<Level>> getLevels();
        Task<Level> getLevel(int IdLevel);
        Task<Level> createLevel(float Duration, string Description);
        Task<Level> updateLevel(int IdLevel, float? Duration = null, string? Description = null);
        Task<bool> deleteLevel(int IdLevel);

    }


    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _LevelRepository;


        public LevelService(ILevelRepository LevelRepository)
        {
            _LevelRepository = LevelRepository;
        }

        public async Task<Level> createLevel(float Duration, string Description)
        {
            return await _LevelRepository.CreateLevel(Duration, Description);
        }

        public async Task<bool> deleteLevel(int IdLevel)
        {
            await _LevelRepository.DeleteLevel(IdLevel);
            return true;
        }

        public async Task<Level> getLevel(int IdLevel)
        {
            return await _LevelRepository.GetLevel(IdLevel);
        }

        public async Task<List<Level>> getLevels()
        {
            return await _LevelRepository.GetLevels();
        }


        public async Task<Level> updateLevel(int IdLevel, float? Duration = null, string? Description = null)
        {
            Level Level = await getLevel(IdLevel);
            if (IdLevel <= 0)
            {
                throw new ArgumentException("El Id debe ser número positivo");
            }
            if (Level == null)
            {
                return null;
            }

            if (Duration != null || Duration != 0) Level.Duration = (float)Duration;

            if (Description != null) Level.Description = Description;

            return await _LevelRepository.UpdateLevel(Level);

        }
    }

}