using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffePartners.Models;
using CoffePartners.Repository;

namespace CoffePartners.Services
{
    public interface IScoreService
    {
        Task<List<Score>> getScores();
        Task<Score> getScore(int IdScore);
        Task<Score> createScore(float Points, int IdLevel, int IdFarm);
        Task<Score> updateScore(int IdScore, float? Points = null, int? IdLevel = null, int? IdFarm = null);
        Task<bool> deleteScore(int IdScore);
    }

    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _cultivationHarvestRepository;

        public ScoreService(IScoreRepository cultivationHarvestHarvestRepository)
        {
            _cultivationHarvestRepository = cultivationHarvestHarvestRepository;
        }

        public async Task<Score> createScore(float Points, int IdLevel, int IdFarm)
        {
            return await _cultivationHarvestRepository.CreateScore(Points, IdLevel, IdFarm);
        }

        public async Task<bool> deleteScore(int IdScore)
        {
            await _cultivationHarvestRepository.DeleteScore(IdScore);
            return true;
        }

        public async Task<Score> getScore(int IdScore)
        {
            return await _cultivationHarvestRepository.GetScore(IdScore);
        }

        public async Task<List<Score>> getScores()
        {
            return await _cultivationHarvestRepository.GetScores();
        }

        public async Task<Score> updateScore(int IdScore, float? Points = null, int? IdLevel = null, int? IdFarm = null)
        {
            Score cultivationHarvest = await getScore(IdScore);

            if (IdScore <= 0)
            {
                throw new ArgumentException("El ID debes er un número positivo");
            }
            if (cultivationHarvest == null)
            {
                return null;
            }

            if (Points != null || Points != 0) cultivationHarvest.Points = (float)Points;
            if (IdLevel != null || IdLevel != 0) cultivationHarvest.IdLevel = (int)IdLevel;
            if (IdFarm != null || IdFarm != 0) cultivationHarvest.IdFarm = (int)IdFarm;

            return await _cultivationHarvestRepository.UpdateScore(cultivationHarvest);

        }
    }
}