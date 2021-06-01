using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Models;
using TimeTable.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TimeTable.Service;

namespace TimeTable.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly AppDBContext db;
        private readonly UserManager<UserStudent> userManager;

        public AdminController(AppDBContext dBContext, UserManager<UserStudent> _userManager)
        {
            db = dBContext;
            userManager = _userManager;
        }

        public IActionResult Courses() 
        {
            var currentUser = userManager.GetUserAsync(User);
            CoursesViewModel model = new CoursesViewModel();
            model.Courses = db.Courses.ToList();
            model.User = currentUser.Result;
            model.Teachers = DataService.GetTeachers(db);
            return View(model);
        }

        public IActionResult Teachers()
        {
            List<string> teachers_ID = db.UserRoles.Where(a => a.RoleId == "teacher").Select(b => b.UserId).Distinct().ToList();
            List<UserStudent> teachers = new List<UserStudent>();
            foreach (var teacherID in teachers_ID)
            {
                teachers.Add(db.Users.FirstOrDefault(x => x.Id == teacherID));
            }
            return View(teachers);
        }

        public IActionResult Timetable(int Days)
        {
            DateTime lessonsDate = DateTime.Now.AddDays(Days);
            TimetableViewModel viewModel = new TimetableViewModel(lessonsDate);
            viewModel.Days = Days;
            viewModel.Courses = db.Courses.ToList();
            viewModel.Lessons = db.Lessons.Where( x => x.Datetime >= viewModel.Monday && x.Datetime <= viewModel.Sunday).ToList();
            viewModel.Lessons.Add(new Lesson() { Datetime = DateTime.Today.AddYears(10) });
            viewModel.Slots = db.Slots.ToList();
            return View(viewModel);
        }

        public IActionResult News()
        {
            return View(db.NewsPosts.ToList());
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
