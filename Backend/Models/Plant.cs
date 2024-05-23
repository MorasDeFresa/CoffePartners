using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Plant
    {
        [Key] public int IdPlant { get; set; }
        public required float PositionX { get; set; }
        public required float PositionZ { get; set; }
        public required int IdFarm { get; set; }
        [ForeignKey("IdFarm")]
        public Farm Farm { get; set; }
    }
}