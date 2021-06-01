using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class FollowViewModel
    {
        public List<Slot> Slots { get; set; }
        public Course CurCourse { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Lesson> FollowingLesson { get; set; }
        public UserStudent Teacher { get; set; }
        public List<Slot> SlotsOfCourse { get; set; }
    }
}
