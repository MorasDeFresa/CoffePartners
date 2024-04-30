using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class StatesCultivation
    {
        [Key] public int IdStatesCultivation { get; set; }
        public required string NameStateCultivation { get; set; }
    }
}