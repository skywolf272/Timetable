using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeTable.Models;
using TimeTable.Data;
using TimeTable.Service;

namespace TimeTable.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext DB;

        public HomeController(AppDBContext dbContext)
        {
            DB = dbContext;
            
            string AdminID = Guid.NewGuid().ToString();
            string AdminRoleID = Guid.NewGuid().ToString();

            UserStudent userAdmin = new UserStudent()
            {
                Id = AdminID,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
                SecurityStamp = String.Empty
            };
            DB.Users.Add(userAdmin);
            IdentityRole roleAdmin = new IdentityRole()
            {
                Id = AdminRoleID,
                Name = "admin",
                NormalizedName = "ADMIN"
            };
            DB.Roles.Add(roleAdmin);
            IdentityUserRole<string> userRoleAdmin = new IdentityUserRole<string>()
            {
                UserId = AdminID,
                RoleId = AdminRoleID
            };
            DB.UserRoles.Add(userRoleAdmin);
            IdentityRole roleStudent = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "student",
                NormalizedName = "STUDENT"
            };
            DB.Roles.Add(roleStudent);
            IdentityRole roleTeacher = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "teacher",
                NormalizedName = "TEACHER"
            };
            DB.Roles.Add(roleTeacher);
            DB.SaveChanges();
        }

        public IActionResult Index()
        {
            CoursesViewModel viewModel = new CoursesViewModel();
            viewModel.Courses = DB.Courses.ToList();
            viewModel.Teachers = DataService.GetTeachers(DB);
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult News()
        {
            List<NewPost> newPosts = DB.NewsPosts.ToList();
            return View(newPosts);
        }

        public IActionResult Timetable(int Days)
        {
            DateTime lessonsDate = DateTime.Now.AddDays(Days);
            TimetableViewModel viewModel = new TimetableViewModel(lessonsDate);
            viewModel.Days = Days;
            viewModel.Courses = DB.Courses.ToList();
            viewModel.Lessons = DB.Lessons.Where(x => x.Datetime >= viewModel.Monday && x.Datetime <= viewModel.Sunday).ToList();
            viewModel.Lessons.Add(new Lesson() { Datetime = DateTime.Today.AddYears(10) });
            viewModel.Slots = DB.Slots.ToList();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
