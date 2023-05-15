using CTM.Data;
using CTM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Controllers
{
    public class AdminController : Controller
    {

        private readonly DataBaseContext _db;

        public AdminController(DataBaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LanguageData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LanguageData(Language L)
        {
            if (ModelState.IsValid)
            {
                _db.Languages.Add(L);
                _db.SaveChanges();
            }



            return RedirectToAction("Languages", "Admin");
        }
        public ActionResult Qualifications()
        {
            List<Qualification> qualifications = _db.Qualifications.ToList();
            return View(qualifications);
        }
        public IActionResult QualificationData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QualificationData(Qualification L)
        {
            if (ModelState.IsValid)
            {
                _db.Qualifications.Add(L);

                _db.SaveChanges();
            }

            return RedirectToAction("Qualifications", "Admin");
        }
        public ActionResult Languages()
        {
            List<Language> languages = _db.Languages.ToList();
            return View(languages);
        }
        public ActionResult RemoveLanguage(int Id)
        {
            foreach (var language in _db.Languages)
            {
                if (language.Id == Id)
                {
                    return View(language);
                }
            }
            return RedirectToAction("Languages");
        }
        [HttpPost]
        public ActionResult RemoveLanguage(Language language)

        {
            _db.Languages.Remove(language);
            _db.SaveChanges();
            foreach (var links in _db.UserLanguageLinks)
            {
                if (links.languageId == language.Id)
                {
                    _db.UserLanguageLinks.Remove(links);
                }

            }
            _db.SaveChanges();

            return RedirectToAction("Languages", "Admin");

        }
        public ActionResult RemoveQualification(int Id)

        {
            foreach (var qualification in _db.Qualifications)
            {
                if (qualification.Id == Id)
                {
                    return View(qualification);
                }
            }
            return RedirectToAction("Qualifications");
        }
        [HttpPost]
        public ActionResult RemoveQualification(Qualification qualification)
        {


            _db.Qualifications.Remove(qualification);
            _db.SaveChanges();
            foreach (var link in _db.TaskQualificationLinks)
            {
                if (link.qualificationId == qualification.Id)
                {
                    _db.TaskQualificationLinks.Remove(link);
                }

            }
            foreach (var link in _db.UserQualificationLinks)
            {
                if (link.qualificationId == qualification.Id)
                {
                    _db.UserQualificationLinks.Remove(link);
                }

            }
            _db.SaveChanges();

            return RedirectToAction("Qualifications", "Admin");
        }


    }
}
