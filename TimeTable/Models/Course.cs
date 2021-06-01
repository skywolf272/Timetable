using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public string ImgPath { get; set; } = "NOIMG"; //Костыль
        [Required(ErrorMessage = "Teacher is required")]
        public string TeacherId { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}