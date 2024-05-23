using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Farmer
    {
        [Key] public int IdFarmer { get; set; }
        public required string NickNameFarmer { get; set; }
        public required int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}