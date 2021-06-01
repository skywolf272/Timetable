using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Models
{
    public class ProfileViewModel
    {
        public UserStudent Student { get; set; }
        public List<Course> FollowedCourses { get; set; }
        public List<Lesson> FollowedLessons { get; set; }
        public List<Slot> StudentsSlots { get; set; }

        public ProfileViewModel(UserStudent CurrentUser, AppDBContext DB)
        {
            Student = CurrentUser;
            StudentsSlots = DB.Slots.Where(x => x.UserID == Student.Id).AsQueryable().ToList();
            FollowedLessons = new List<Lesson>();
            for (int i = 0; i < StudentsSlots.Count; i++)
            {
                FollowedLessons.Add(DB.Lessons.FirstOrDefault(x => x.ID == StudentsSlots[i].LessonID));
            }

            if (StudentsSlots.Count != 0)
            {
                FollowedCourses = new List<Course>();
                for (int j = 0; j < FollowedLessons.Count; j++)
                {
                    FollowedCourses.Add(DB.Courses.FirstOrDefault(x => x.ID == FollowedLessons[j].CourseID));
                }
            }
        }
    }
}
