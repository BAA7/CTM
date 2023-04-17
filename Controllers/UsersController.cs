﻿using CTM.Data;
using CTM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

namespace CTM.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataBaseContext _db;

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
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using(DataBaseContext db=new DataBaseContext(new DbContextOptions<DataBaseContext>()))
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.eMail + " registration successful.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (DataBaseContext db = _db)
            {
                var usr = db.Users.SingleOrDefault(u => user.eMail == u.eMail && user.password == u.password);
                if (usr != null)
                {
                    HttpContext.Session.SetString("Id", usr.Id.ToString());
                    HttpContext.Session.SetString("name", usr.name.ToString());
                    //Session["Id"] = usr.Id.ToString();
                    //Session["name"] = usr.name.ToString();
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
                return View("LoggedIn",HttpContext.Session.GetString("name"));
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
