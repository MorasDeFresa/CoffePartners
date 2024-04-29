using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class CultivationHarvest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCultivationHarvest { get; set; }
        public required float WeightHarvest { get; set; }
        public Cultivation IdCultivation { get; internal set; }
        public Harvest IdHarvest { get; internal set; }
    }
}