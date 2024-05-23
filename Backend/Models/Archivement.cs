using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Archivement
    {
        [Key] public int IdArchivement { get; set; }
        public required string NameArchivement { get; set; }
        [StringLength(1000)] public required string DescriptionArchivement { get; set; }
    }
}