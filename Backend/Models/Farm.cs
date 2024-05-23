using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Farm
    {
        [Key] public int IdFarm { get; set; }
        public required string NameFarm { get; set; }
        public required DateTime CreateDateFarm { get; set; }
        public required DateTime UpdateDateFarm { get; set; }
        public required int IdFarmer { get; set; }
        [ForeignKey("IdFarmer")]
        public Farmer Farmer { get; set; }
        public required float Latitude { get; set; }
        public required float Longitude { get; set; }
    }
}