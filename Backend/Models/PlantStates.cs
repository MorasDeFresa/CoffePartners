using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class PlantStates
    {
        [Key] public int IdPlantState { get; set; }
        public required string NamePlantState { get; set; }
        [StringLength(1000)] public required string DescriptionPlantState { get; set; }
    }
}