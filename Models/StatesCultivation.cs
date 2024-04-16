using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class StatesCultivation
    {
        [Key] public int IdStateCultivation { get; set; }
        public required string NameStateCultivation { get; set; }
        public ICollection<Cultivation> Cultivation { get; set; }
    }
}