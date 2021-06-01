using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTable.Models
{
    public class CreateCourseViewModel
    {
        public Course Course { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public IFormFile Img { get; set; }
        public List<UserStudent> Teachers { get; set; }
        public SelectList SelectListTeacher { get; set; }

        //public CreateCourseViewModel(List<UserStudent> teachers)
        //{
        //    Teachers = teachers;
        //}
    }
}
