using System;
using Microsoft.AspNetCore.Identity;

namespace TimeTable.Models
{
    public class UserStudent : IdentityUser
    {
        public UserStudent()
        {
            Id = Guid.NewGuid().ToString(); 
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
