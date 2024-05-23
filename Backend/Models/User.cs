using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class User
    {
        [Key] public int IdUser { get; set; }
        public required string EmailUser { get; set; }
        [StringLength(1000)] public required string PasswordUser { get; set; }
        public required string NameUser { get; set; }
        public required string SurnameUser { get; set; }
        public required DateOnly DateBorn { get; set; }
    }
}