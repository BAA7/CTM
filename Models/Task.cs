using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Models
{
    public class Task
    {
        public int Id { get; set; }
        string name { get; set; }
        int[] qualificationsRequired { get; set; }
        string languageRequired { get; set; }
        int deadline { get; set; }
    }
}
