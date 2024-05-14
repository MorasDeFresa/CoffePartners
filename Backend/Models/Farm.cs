using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Farm
    {
        [Key] public int IdFarm { get; set; }
        public required string NameFarm { get; set; }
        public required int IdPlayer { get; set; }
        [ForeignKey("IdPlayer")]
        public Player Player { get; set; }
        public required float SizeFarm { get; set; }
    }
}