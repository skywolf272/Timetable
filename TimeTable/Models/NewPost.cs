using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models
{
    public class NewPost
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Desc { get; set; }
        public string ImgPath { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
    }
}
