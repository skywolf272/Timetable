using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTable.Data;
using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models
{
    public class LessonViewModel
    {
        public Lesson Lesson { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Course> Courses { get; set; }
        public List<UserStudent> Teachers { get; set; }
        public Course Course { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public TimeSpan TimeFix { get; set; }

        public void FixDate()
        {
            Lesson.Datetime = Lesson.Datetime.AddHours(TimeFix.Hours);
        }

        public bool IsLessonUnique()
        {
            if (Lessons != null)
            {
                for (int i = 0; i < Lessons.Count; i++)
                {
                    if (Lessons[i].Datetime == Lesson.Datetime)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
