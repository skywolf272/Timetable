using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Models;
using TimeTable.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTable.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CreatorController : Controller
    {
        private readonly AppDBContext db;
        private readonly UserManager<UserStudent> userManager;
        private readonly IWebHostEnvironment webHostEnv;
        private readonly ILogger<CreatorController> logg;

        public CreatorController(AppDBContext dBContext, UserManager<UserStudent> _userManager, IWebHostEnvironment _webHost, ILogger<CreatorController> logger)
        {
            db = dBContext;
            userManager = _userManager;
            webHostEnv = _webHost;
            logg = logger;
        }

        [HttpGet]
        public IActionResult CreateCourse() //Создание курса админом на клиенте
        {
            //Достать пользователей из роли учитель                     TODO: переписать это дело что бы не копировать код
            string teacherRoleID = db.Roles.FirstOrDefault(x => x.Name == "teacher").Id;
            List<string> teachers_ID = db.UserRoles.Where(a => a.RoleId == teacherRoleID).Select(b => b.UserId).Distinct().ToList();
            List<UserStudent> teachers = new List<UserStudent>();
            foreach (var teacherID in teachers_ID)
            {
                teachers.Add(db.Users.FirstOrDefault(x => x.Id == teacherID));
            }
            

            CreateCourseViewModel courseViewModel = new CreateCourseViewModel()
            {
                Teachers = teachers,
                SelectListTeacher = new SelectList(teachers, "id", "name"),
            };

            return View(courseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseViewModel courseModel) //Создание курса на сервер и бд
        {
            if (ModelState.IsValid)
            {
                courseModel.Course.ImgPath = "/img/" + courseModel.Img.FileName;
                if (courseModel.Course.ImgPath != "/img/NOIMG")
                {
                    using (var fileStream = new FileStream(webHostEnv.WebRootPath + courseModel.Course.ImgPath, FileMode.Create))
                    {
                        await courseModel.Img.CopyToAsync(fileStream);
                    }

                    db.Courses.Add(courseModel.Course);
                    db.SaveChanges();
                    return RedirectToAction("Courses", "Admin", new { area = "Admin" });
                }
            }

            //Достать пользователей из роли учитель                     TODO: переписать это дело что бы не копировать код
            string teacherRoleID = db.Roles.FirstOrDefault(x => x.Name == "teacher").Id;
            List<string> teachers_ID = db.UserRoles.Where(a => a.RoleId == teacherRoleID).Select(b => b.UserId).Distinct().ToList();
            List<UserStudent> teachers = new List<UserStudent>();
            foreach (var teacherID in teachers_ID)
            {
                teachers.Add(db.Users.FirstOrDefault(x => x.Id == teacherID));
            }

            CreateCourseViewModel courseViewModel = new CreateCourseViewModel()
            {
                Teachers = teachers 
            };
            return View(courseViewModel);
        }

        [HttpGet]
        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(RegistrationUserModel teacher)
        {
            if (ModelState.IsValid)
            {

                UserStudent user = new UserStudent { FirstName = teacher.FirstName, SecondName = teacher.SecondName, UserName = teacher.UserName };
                var result = await userManager.CreateAsync(user, teacher.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "teacher");
                    db.SaveChanges();
                    return RedirectToAction("Teachers", "Admin", new { area = "Admin" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateLesson()
        {
            return View(GetFinishedLessonModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLesson( LessonViewModel model )
        {
            if (ModelState.IsValid)
            {
                model.FixDate();
                model.Lessons = db.Lessons.OrderBy( x => x.Datetime).ToList();
                if (model.IsLessonUnique())
                {
                    db.Lessons.Add(model.Lesson);
                    await db.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError(nameof(model), "В это время уже есть занятие.");
                }
            }
            //Просто позор, это ужасно - неизевстно почему так работает;
            return View(GetFinishedLessonModel());
        }

        [HttpPost]
        public IActionResult SaveLesson(string lessonCourseID, DateTime lessonToSaveID)
        {
            return RedirectToAction("CreateLesson", "Creator", new { courseID = lessonCourseID, dateOfLessons = DateTime.Now});
        }

        public async Task<IActionResult> DeleteCourse(int ID)
        {
            Course courseToDelete = db.Courses.FirstOrDefault( x => x.ID == ID);
            if ( courseToDelete != null)
            {
                List<Lesson> lessonsToDelete = db.Lessons.Where( x => x.CourseID == courseToDelete.ID).ToList();
                for (int i = 0; i < lessonsToDelete.Count; i++)
                {
                    var slotToRemove = db.Slots.FirstOrDefault(x => x.LessonID == lessonsToDelete[i].ID);
                    if (slotToRemove != null)
                    {
                        db.Remove(slotToRemove);
                    }
                    db.Remove(lessonsToDelete[i]);
                }
                db.Remove(courseToDelete);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Courses", "Admin", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult Teachers()
        {
            return View(GetTeachers());
        }

        public List<UserStudent> GetTeachers()
        {
            //Достать пользователей из роли учитель      TODO: переписать это дело что бы не копировать код
            string teacherRoleID = db.Roles.FirstOrDefault(x => x.Name == "teacher").Id;
            List<string> teachers_ID = db.UserRoles.Where(a => a.RoleId == teacherRoleID).Select(b => b.UserId).Distinct().ToList();
            List<UserStudent> teachers = new List<UserStudent>();
            foreach (var teacherID in teachers_ID)
            {
                teachers.Add(db.Users.FirstOrDefault(x => x.Id == teacherID));
            }

            return teachers;
        }

        public LessonViewModel GetFinishedLessonModel()
        {
            LessonViewModel viewModel = new LessonViewModel();
            viewModel.Lessons = db.Lessons.OrderBy( x => x.Datetime).ToList();
            viewModel.Courses = db.Courses.ToList();
            viewModel.Teachers = GetTeachers();
            return viewModel;
        }

        [HttpGet]
        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(NewPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = Guid.NewGuid().ToString();
                string fileExtansion = Path.GetExtension(model.ImgFile.FileName);
                model.New.ImgPath = "/img/" + uniqueFileName + fileExtansion;
                using (var fileStream = new FileStream( Path.Combine(webHostEnv.WebRootPath + "/img/", uniqueFileName) + fileExtansion, FileMode.Create))
                {
                    await model.ImgFile.CopyToAsync(fileStream);
                }
                model.New.Date = DateTime.Today;
                db.NewsPosts.Add(model.New);
                await db.SaveChangesAsync();
                return RedirectToAction("News", "Admin", new { area = "Admin" });
            }
            ModelState.AddModelError(nameof(model), "Ошибка");
            return View(model);
        }

        public async Task<IActionResult> DeleteNew(int ID)
        {
            db.Remove( db.NewsPosts.FirstOrDefault( x => x.ID == ID) );
            await db.SaveChangesAsync();
            return RedirectToAction("News", "Admin", new { area = "Admin" });
        }
    }
}
