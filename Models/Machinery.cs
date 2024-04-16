using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Machinery
    {
        [Key] public int IdMachinery { get; set; }
        public required string NameMachine { get; set; }
        public required string DescriptionMachine { get; set; }
        public required float PriceMachine { get; set; }
        public ICollection<TypeProcess> TypeProcesses { get; set; }
    }
}