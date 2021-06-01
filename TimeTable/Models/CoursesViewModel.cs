using TimeTable.Models;
using System.Collections.Generic;

namespace TimeTable.Models
{
    public class CoursesViewModel
    {
        public List<Course> Courses { get; set; }
        public UserStudent User { get; set; }
        public List<UserStudent> Teachers { get; set; }

    }
}
