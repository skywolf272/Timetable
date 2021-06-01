using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class TimetableViewModel
    {
        public List<Course> Courses { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Slot> Slots { get; set; }
        public int Days { get; set; } = 0;
        public DateTime LessonsDate { get; set; }
        public DateTime Monday { get; set; }
        public DateTime Sunday { get; set; }

        public TimetableViewModel(DateTime date)
        {
            LessonsDate = date;
            Monday = date.StartOfWeek(DayOfWeek.Monday);
            Sunday = Monday.AddDays(7);
        }

        public int NextDays()
        {
            return Days + 7;
        }

        public int PrevioustDays()
        {
            return Days - 7;
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
