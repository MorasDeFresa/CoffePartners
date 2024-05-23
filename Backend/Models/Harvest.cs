using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Harvest
    {
        [Key] public int IdHarvest { get; set; }
        public required float WeightHarvest { get; set; }
        public required DateTime DateBasketProcess { get; set; }
        public required int IdPlant { get; set; }
        [ForeignKey("IdPlant")]
        public Plant Plant { get; set; }
        public required int IdTypeQuality { get; set; }
        [ForeignKey("IdTypeQuality")]
        public TypeQuality TypeQuality { get; set; }

    }
}