using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Cultivation
    {
        [Key] public int IdCultivation { get; set; }
        public DateTime DateCultivation { get; set; }
        public required float Area { get; set; }
        public required int IdFarm { get; set; }
        [ForeignKey("IdFarm")]
        public Farm Farm { get; set; }
        public required int IdStateCultivation { get; set; }
        [ForeignKey("IdStateCultivation")]
        public StatesCultivation StatesCultivation { get; set; }

    }
}