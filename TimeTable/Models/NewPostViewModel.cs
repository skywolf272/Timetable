using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models
{
    public class NewPostViewModel
    {
        public NewPost New { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public IFormFile ImgFile { get; set; }
    }
}
