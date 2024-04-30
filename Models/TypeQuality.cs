using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class TypeQuality
    {
        [Key] public int IdTypeQuality { get; set; }
        public required string NameQuality { get; set; }
        public required float PriceByGr { get; set; }
    }
}