using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Models
{
    public class UserChiefLink
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public int chiefId { get; set; }
    }
}
