using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class FarmerScore
    {
        [Key] public int IdFarmerScore { get; set; }
        public required int IdFarmer { get; set; }
        [ForeignKey("IdFarmer")]
        public Farmer Farmer { get; set; }
        public required int IdScore { get; set; }
        [ForeignKey("IdScore")]
        public Score Score { get; set; }
        public required DateTime DateScore { get; set; }
        public required float PointScore { get; set; }
    }
}