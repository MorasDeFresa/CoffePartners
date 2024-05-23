using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Posts
    {
        [Key] public int IdPost { get; set; }
        public required string TitlePost { get; set; }
        public required DateTime DatePost { get; set; }
        [StringLength(1000)] public required string ImgUrl { get; set; }
        [StringLength(1000)] public required string DescriptionPost { get; set; }
        public required int IdAdmin { get; set; }
        [ForeignKey("IdAdmin")]
        public Admin Admin { get; set; }
    }
}