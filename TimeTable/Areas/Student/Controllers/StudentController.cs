using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Models;
using TimeTable.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using TimeTable.Service;

namespace TimeTable.Areas.Student
{
    [Area("Student")]
    [Authorize(Roles = "student")]
    public class StudentController : Controller
    {
        private readonly AppDBContext DB;
        private readonly UserManager<UserStudent> userManager;

        public StudentController(AppDBContext dBContext, UserManager<UserStudent> _userManager)
        {
            DB = dBContext;
            userManager = _userManager;
        }

        public IActionResult Courses()
        {
            CoursesViewModel model = new CoursesViewModel();
            model.Courses = DB.Courses.ToList();
            UserStudent CurrentUser = userManager.GetUserAsync(User).Result;
            model.User = CurrentUser;
            model.Teachers = DataService.GetTeachers(DB);
            return View(model);
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

        public IActionResult News()
        {
            return View(DB.NewsPosts.ToList());
        }

        public IActionResult Profile()
        {
            UserStudent CurrentUser = userManager.GetUserAsync(User).Result;
            ProfileViewModel viewModel = new ProfileViewModel(CurrentUser, DB);
            return View(viewModel);
        }

        public IActionResult More(int ID)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Follow(int ID)
        {
            UserStudent CurrentUser = userManager.GetUserAsync(User).Result;
            FollowViewModel viewModel = new FollowViewModel();
            viewModel.Slots = DB.Slots.Where(x => x.UserID == CurrentUser.Id).AsQueryable().ToList();
            viewModel.SlotsOfCourse = DB.Slots.ToList();
            viewModel.Lessons = DB.Lessons.Where( x => x.CourseID == ID && x.Datetime >= DateTime.Today ).OrderBy(x => x.Datetime).AsQueryable().ToList();
            viewModel.CurCourse = DB.Courses.FirstOrDefault( x => x.ID == ID);
            viewModel.Teacher = DB.Users.FirstOrDefault( x => x.Id == viewModel.CurCourse.TeacherId);
            viewModel.FollowingLesson = new List<Lesson>();
            for (int i = 0; i < viewModel.Slots.Count; i++)
            {
                viewModel.FollowingLesson.Add(viewModel.Lessons.FirstOrDefault(x => x.ID == viewModel.Slots[i].LessonID));
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FollowLesson( int lessonToFollowID )
        {
            UserStudent CurrentUser = userManager.GetUserAsync(User).Result;
            Slot slotToAdd = new Slot() { LessonID = lessonToFollowID, UserID = CurrentUser.Id };
            DB.Slots.Add(slotToAdd);
            await DB.SaveChangesAsync();
            return RedirectToAction("Follow","Student", new { area = "Student", ID = DB.Lessons.FirstOrDefault( x => x.ID == lessonToFollowID).CourseID });
        }

        [HttpPost]
        public async Task<IActionResult> UnFollow( int lessonToUnFollowID )
        {
            UserStudent CurrentUser = userManager.GetUserAsync(User).Result;
            Slot slotToRemove = new Slot() { LessonID = lessonToUnFollowID, UserID = CurrentUser.Id };
            slotToRemove = DB.Slots.FirstOrDefault( x => x.LessonID == slotToRemove.LessonID && x.UserID == slotToRemove.UserID);
            DB.Slots.Attach(slotToRemove);
            DB.Slots.Remove(slotToRemove);
            await DB.SaveChangesAsync();
            return RedirectToAction("Follow", "Student", new { area = "Student", ID = DB.Lessons.FirstOrDefault( x => x.ID == lessonToUnFollowID ).CourseID });
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}