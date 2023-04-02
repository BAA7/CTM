using CTM.Data;
using CTM.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataBaseContext _db;

        public UsersController(DataBaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            dynamic dbLists = new ExpandoObject();
            dbLists.Users = _db.Users.ToList();
            dbLists.Qualifications = new List<string>();
            foreach(var user in _db.Users)
            {
                List<string> qualificationsList = new List<string>();
                foreach(var link in _db.UserQualificationLinks)
                {
                    if (link.userId == user.Id)
                    {
                        foreach(var qualification in _db.Qualifications)
                        {
                            if (qualification.Id == link.qualificationId)
                            {
                                qualificationsList.Add(qualification.name);
                            }
                        }
                    }
                }
                dbLists.Qualifications.Add(String.Join(", ",qualificationsList));
            }
            IEnumerable<User> objList = _db.Users;
            return View(dbLists);
        }
    }
}
