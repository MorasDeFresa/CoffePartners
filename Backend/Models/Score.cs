using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Score
    {
        [Key] public int IdScore { get; set; }
        public required string NameScore { get; set; }
        public required float MinimunPoints { get; set; }
        public required float MaximunPoints { get; set; }
        [StringLength(1000)] public required string DescriptionScore { get; set; }
    }
}