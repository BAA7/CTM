using CTM.Data;
using CTM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;

namespace CTM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DataBaseContext _db;

        public HomeController(DataBaseContext db)
        {
            _db = db;
        }

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            using (DataBaseContext db = _db)
            {
                var usr = db.Users.SingleOrDefault(u => user.eMail == u.eMail && user.password == u.password);
                if (usr != null)
                {
                    HttpContext.Session.SetString("Id", usr.Id.ToString());
                    HttpContext.Session.SetString("name", usr.name.ToString());
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email and/or password is incorrect.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View("LoggedIn", HttpContext.Session.GetString("name"));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
