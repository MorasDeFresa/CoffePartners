using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class TypeProcess
    {
        [Key] public int IdTypeProcess { get; set; }
        public required string NameProcess { get; set; }
        public required string DescriptionProcess { get; set; }
        public required int IdMachinery { get; set; }
        [ForeignKey("IdMachinery")]
        public Machinery Machinery { get; set; }
    }
}