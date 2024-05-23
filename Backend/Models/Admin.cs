using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Admin
    {
        [Key] public int IdAdmin { get; set; }
        public required int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public bool IsActive { get; set; } = true;
        public required DateTime DateAdminState { get; set; }
    }
}