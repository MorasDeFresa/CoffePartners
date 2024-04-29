using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Cultivation
    {
        [Key] public int IdCultivation { get; set; }
        public DateTime DateCultivation { get; set; }
        public required float Area { get; set; }
        public required Farm IdFarm { get; set; }
        public required StatesCultivation IdStateCultivation { get; set; }

    }
}