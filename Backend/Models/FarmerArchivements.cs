using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class FarmerArchivements
    {
        [Key] public int IdFarmerArchivement { get; set; }
        public required DateTime DateArchivement { get; set; }
        public required int IdArchivement { get; set; }
        [ForeignKey("IdArchivement")]
        public Archivement Archivement { get; set; }
        public required int IdFarmer { get; set; }
        [ForeignKey("IdFarmer")]
        public Farmer Farmer { get; set; }
    }
}