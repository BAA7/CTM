using CTM.Data;
using CTM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;


namespace CTM.Controllers
{
    public class UsersController : Controller
    {
        public readonly DataBaseContext _db;

        public UsersController(DataBaseContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            dynamic dbLists = new ExpandoObject();
            dbLists.Users = _db.Users.ToList();
            dbLists.Qualifications = new List<string>();
            dbLists.Languages = new List<string>();
            foreach(var user in _db.Users)
            {
                List<string> qualificationsList = new List<string>();
                List<string> languagesList = new List<string>();
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
                foreach (var link in _db.UserLanguageLinks)
                {
                    if (link.userId == user.Id)
                    {
                        foreach (var language in _db.Languages)
                        {
                            if (language.Id == link.languageId)
                            {
                                languagesList.Add(language.name);
                            }
                        }
                    }
                }
                dbLists.Qualifications.Add(String.Join("; ",qualificationsList));
                dbLists.Languages.Add(String.Join(", ", languagesList));
            }
            IEnumerable<User> objList = _db.Users;
            return View(dbLists);
        }

        public ActionResult Register()
        {
            dynamic registerData = new ExpandoObject();

            ViewBag.Qualifications = new List<SelectListItem>();
            foreach(var qualification in _db.Qualifications)
            {
                ViewBag.Qualifications.Add(new SelectListItem() { Text = qualification.name, Value = qualification.Id.ToString() });
            }

            ViewBag.Languages = new List<SelectListItem>();
            foreach(var language in _db.Languages)
            {
                ViewBag.Languages.Add(new SelectListItem() { Text = language.name, Value = language.Id.ToString() });
            }

            ViewBag.Users = new List<SelectListItem>();
            foreach (var user in _db.Users)
            {
                ViewBag.Users.Add(new SelectListItem() { Text = user.name, Value = user.Id.ToString() });
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel userModel)
        {
            if (ModelState.IsValid)
            {
                using(DataBaseContext db=new DataBaseContext(new DbContextOptions<DataBaseContext>()))
                {
                    //db.Users.Add(user);
                    //db.SaveChanges();
                    db.Users.Add(userModel.user);
                    foreach (var qualification in userModel.qualificationsId)
                    {
                        db.UserQualificationLinks.Add(new UserQualificationLink { userId = userModel.user.Id, qualificationId = qualification });
                    }
                    foreach (var language in userModel.languagesId)
                    {
                        db.UserLanguageLinks.Add(new UserLanguageLink { userId = userModel.user.Id, languageId = language });
                    }
                    db.UserChiefLinks.Add(new UserChiefLink { userId = userModel.user.Id, chiefId = userModel.chiefId });
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = userModel.user.eMail + " registration successful.";
                }
            }
            return View();
        }

        public ActionResult Profile()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                dynamic userInfo = new ExpandoObject();
                //userInfo.User = HttpContext.Session;
                userInfo.Id = HttpContext.Session.GetString("Id");
                userInfo.Name = HttpContext.Session.GetString("name");
                userInfo.Qualifications = new List<string>();
                List<string> qualificationsList = new List<string>();
                foreach(var qualificationLink in _db.UserQualificationLinks)
                {
                    if (qualificationLink.userId.ToString() == userInfo.Id)
                    {
                        foreach(var qualification in _db.Qualifications)
                        {
                            if (qualification.Id == qualificationLink.qualificationId)
                            {
                                userInfo.Qualifications.Add(qualification.name);
                            }
                        }
                    }
                }
                List<string> languagesList = new List<string>();
                foreach(var languageLink in _db.UserLanguageLinks)
                {
                    if (languageLink.userId.ToString() == userInfo.Id)
                    {
                        foreach(var language in _db.Languages)
                        {
                            if (language.Id == languageLink.languageId)
                            {
                                languagesList.Add(language.name);
                            }
                        }
                    }
                }
                //userInfo.Qualifications = String.Join("; ", qualificationsList);
                userInfo.Languages = String.Join(", ", languagesList);

                return View("Profile", userInfo);
            }
            else
            {
                //return HomeController.Index();
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
