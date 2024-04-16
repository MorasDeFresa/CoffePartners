using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Farm
    {
        [Key] public int IdFarm { get; set; }
        public required float SizeFarm { get; set; }
        public required string NameFarm { get; set; }
        public ICollection<Score> Scores { get; set; }
        public required Player IdPlayer { get; set; }
    }
}