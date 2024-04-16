using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffePartners.Models
{
    public class Player
    {
        [Key] public int IdPlayer { get; set; }
        public required string EmailPlayer { get; set; }
        public required string PasswordPlayer { get; set; }
        public required string NicknamePlayer { get; set; }
        public ICollection<Farm> Farms { get; set; }
    }
}