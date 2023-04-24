using CTM.Data;
using CTM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CTM.Controllers
{
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;

        private readonly DataBaseContext _db;

        public TasksController(DataBaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                dynamic tasksData = new ExpandoObject();
                User mePerformers = new Models.User();
                foreach (var user in _db.Users)
                {
                    if (user.Id.ToString() == HttpContext.Session.GetString("Id"))
                    {
                        mePerformers = user;
                        break;
                    }
                }
                List<User> subordinatePerformers = new List<User>();
                List<User> otherPerformers = new List<User>();
                List<int> subordinates = new List<int>();
                List<Models.Task> myTasks = new List<Models.Task>();
                List<Models.Task> subordinatesTasks = new List<Models.Task>();
                List<Models.Task> otherTasks = new List<Models.Task>();
                foreach (var task in _db.Tasks)
                {
                    if (task.performerId.ToString() == HttpContext.Session.GetString("Id"))
                    {
                        myTasks.Add(task);
                    }
                    else if(_db.UserChiefLinks.Any(link=>
                                                   link.chiefId.ToString() == HttpContext.Session.GetString("Id") &&
                                                   link.userId == task.performerId))
                    {
                        subordinatesTasks.Add(task);
                        foreach (var user in _db.Users)
                        {
                            if (user.Id == task.performerId)
                            {
                                subordinatePerformers.Add(user);
                                break;
                            }
                        }
                    }
                    else
                    {
                        otherTasks.Add(task);
                        foreach (var user in _db.Users)
                        {
                            if (user.Id == task.performerId)
                            {
                                otherPerformers.Add(user);
                                break;
                            }
                        }
                    }
                }
                tasksData.MyTasks = myTasks;
                tasksData.SubordinatesTasks = subordinatesTasks;
                tasksData.OtherTasks = otherTasks;
                tasksData.Me = mePerformers;
                tasksData.SubordinatePerformers = subordinatePerformers;
                tasksData.OtherPerformers = otherPerformers;
                return View(tasksData);
            }
            return RedirectToAction("Index","Home");
        }

        public ActionResult Add()
        {
            ViewBag.Qualifications = new List<SelectListItem>();
            foreach (var qualification in _db.Qualifications)
            {
                ViewBag.Qualifications.Add(new SelectListItem() { Text = qualification.name, Value = qualification.Id.ToString() });
            }

            ViewBag.Languages = new List<SelectListItem>();
            foreach (var language in _db.Languages)
            {
                ViewBag.Languages.Add(new SelectListItem() { Text = language.name, Value = language.Id.ToString() });
            }

            ViewBag.Users = new List<SelectListItem>();
            foreach (var user in _db.Users)
            {
                if (user.Id.ToString() == HttpContext.Session.GetString("Id") ||
                    _db.UserChiefLinks.Any(link => user.Id == link.userId && link.chiefId.ToString() == HttpContext.Session.GetString("Id")))
                {
                    ViewBag.Users.Add(new SelectListItem() { Text = user.name, Value = user.Id.ToString() });
                }
                //ViewBag.Users.Add(new SelectListItem() { Text = user.name, Value = user.Id.ToString() });
            }

            return View();
        }
        [HttpPost]
        public ActionResult Add(TaskCreateModel taskModel)
        {
            if (ModelState.IsValid)
            {
                _db.Tasks.Add(taskModel.task);
                _db.SaveChanges();
                foreach(var qualification in taskModel.qualificationsId)
                {
                    _db.TaskQualificationLinks.Add(new TaskQualificationLink { taskId = GetTaskId(taskModel), qualificationId = qualification });
                }
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public int GetTaskId(TaskCreateModel taskModel)
        {
            foreach(var task in _db.Tasks)
            {
                if(task.name==taskModel.task.name &&
                   task.performerId==taskModel.task.performerId &&
                   task.languageRequiredId == taskModel.task.languageRequiredId)
                {
                    return task.Id;
                }
            }
            return 0;
        }
    }
}
