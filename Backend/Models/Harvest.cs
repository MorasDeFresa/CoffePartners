using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Harvest
    {
        [Key] public int IdHarvest { get; set; }
        public DateTime DateHarvest { get; set; }
        public required int IdTypeQuality { get; set; }
        [ForeignKey("IdTypeQuality")]
        public TypeQuality TypeQuality { get; set; }
    }
}