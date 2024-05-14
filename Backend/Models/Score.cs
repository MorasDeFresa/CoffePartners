using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Score
    {
        [Key] public int IdScore { get; set; }
        public required float Points { get; set; }
        public required int IdLevel { get; set; }
        [ForeignKey("IdLevel")]
        public Level Level { get; set; }
        public required int IdFarm { get; set; }
        [ForeignKey("IdFarm")]
        public Farm Farm { get; set; }
    }
}