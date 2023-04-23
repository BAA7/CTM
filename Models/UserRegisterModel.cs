using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTM.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTM.Models
{
    public class UserRegisterModel
    {
        public User user { get; set; }
        public List<int> qualificationsId { get; set; }
        public List<int> languagesId { get; set; }
        public int chiefId { get; set; }
    }
}
