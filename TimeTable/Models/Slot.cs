using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models
{
    public class Slot
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lesson")]
        public int LessonID { get; set; }
        [Required(ErrorMessage = "User")]
        public string UserID { get; set; }
    }
}
