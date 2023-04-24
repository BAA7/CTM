using CTM.Data;
using CTM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataBaseContext _db;

        public AdminController(DataBaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Qualifications()
        {
            List<Qualification> qualifications = _db.Qualifications.ToList();
            return View(qualifications);
        }

        public ActionResult Languages()
        {
            List<Language> languages = _db.Languages.ToList();
            return View(languages);
        }
    }
}
