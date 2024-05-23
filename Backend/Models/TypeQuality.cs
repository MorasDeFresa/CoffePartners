using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class TypeQuality
    {
        [Key] public int IdTypeQuality { get; set; }
        public required string NameTypeQuality { get; set; }
        [StringLength(1000)] public required string DescriptionTypeQuality { get; set; }
    }
}