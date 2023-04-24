using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Models
{
    public class TaskCreateModel
    {
        public Task task { get; set; }
        public List<int> qualificationsId { get; set; }
    }
}
