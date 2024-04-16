using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class HarvestProcess
    {
        [Key] public int IdHarvestProcess { get; set; }
        public required CultivationHarvest IdCultivationHarvest { get; set; }
        public required TypeProcess IdTypeProcess { get; set; }
        public required float HeightWastedGrain { get; set; }
    }
}