using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class CultivationHarvest
    {
        [Key] public int IdCultivationHarvest { get; set; }
        public required Cultivation IdCultivation { get; set; }
        public required Harvest IdHarvest { get; set; }
        public required float WeightHarvest { get; set; }
        public ICollection<HarvestProcess> HarvestProcesses { get; set; }
    }
}