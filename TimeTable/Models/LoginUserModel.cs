using System;
using System.ComponentModel.DataAnnotations;

namespace TimeTable.Models
{
    public class LoginUserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
