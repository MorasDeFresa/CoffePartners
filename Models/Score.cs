using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Score
    {
        [Key] public int IdScore { get; set; }
        public float Points { get; set; }
        public required Level IdLevel { get; set; }
        public required Farm IdFarm { get; set; }
    }
}