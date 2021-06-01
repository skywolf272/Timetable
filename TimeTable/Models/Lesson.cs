using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        //[RegularExpression(@"[1-7]$")]
        [Required(ErrorMessage = "Choose date")]
        [DataType(DataType.Date)]
        public DateTime Datetime { get; set; }
        [Required(ErrorMessage = "Choose time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        public int DurationInMinutes { get; set; }
        [Required(ErrorMessage = "Teacher is required")]
        public string TeacherId { get; set; }
        [Required(ErrorMessage = "Course is required")]
        public int CourseID { get; set; }
        [Required(ErrorMessage = "Count is required")]
        public int SlotsCount { get; set; }

        List<Slot> Slots { get; set; }
    }
}
