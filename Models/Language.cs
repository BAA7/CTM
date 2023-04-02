using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
