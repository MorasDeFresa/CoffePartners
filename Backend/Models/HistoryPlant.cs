using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class HistoryPlant
    {
        [Key] public int IdHistoryPlant { get; set; }
        public required DateTime DatePlantProcess { get; set; }
        public required int IdPlant { get; set; }
        [ForeignKey("IdPlant")]
        public Plant Plant { get; set; }
        public required int IdPlantState { get; set; }
        [ForeignKey("IdPlantState")]
        public PlantStates PlantStates { get; set; }
    }
}
