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
        public string name { get; set; }
        public int languageRequiredId { get; set; }
        public string performerId { get; set; }
        public DateTime deadline { get; set; }
    }
}
