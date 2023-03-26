using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Models
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string eMail { get; set; }
        public string password { get; set; }
        public int[] qualificationCodes { get; set; }
        public string[] languagesKnown { get; set; }
    }
}
