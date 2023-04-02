using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        string name { get; set; }
        int[] qualificationsRequired { get; set; }
        string languageRequired { get; set; }
        int deadline { get; set; }
    }
}
