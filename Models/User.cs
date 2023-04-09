using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string eMail { get; set; }
        [Required]
        public string password { get; set; }
        //public List<int> qualificationCodes { get; set; }
        //public List<string> languagesKnown { get; set; }
    }
}
