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
        public required int IdCultivation { get; set; }
        [ForeignKey("IdCultivation")]
        public Cultivation Cultivation { get; internal set; }
        public required int IdHarvest { get; set; }
        [ForeignKey("IdHarvest")]
        public Harvest Harvest { get; internal set; }
    }
}