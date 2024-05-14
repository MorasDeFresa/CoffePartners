using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Level
    {
        [Key] public int IdLevel { get; set; }
        public required float Duration { get; set; }
        public required string Description { get; set; }
    }
}