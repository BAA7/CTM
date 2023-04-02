using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Models
{
    public class UserQualificationLink
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public int qualificationId { get; set; }
    }
}
