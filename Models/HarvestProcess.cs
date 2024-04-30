using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class HarvestProcess
    {
        [Key] public int IdHarvestProcess { get; set; }
        public required int IdCultivationHarvest { get; set; }
        [ForeignKey("IdCultivationHarvest")]
        public CultivationHarvest CultivationHarvest { get; set; }
        public required int IdTypeProcess { get; set; }
        [ForeignKey("IdTypeProcess")]
        public TypeProcess TypeProcess { get; set; }
        public required float HeightWastedGrain { get; set; }
    }
}