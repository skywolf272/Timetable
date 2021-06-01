using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTable.Models;
using TimeTable.Data;

namespace TimeTable.Service
{
    public class DataService
    {
        public static List<UserStudent> GetTeachers( AppDBContext DB )
        {
            //Достать пользователей из роли учитель                     TODO: переписать это дело что бы не копировать код
            string teacherRoleID = DB.Roles.FirstOrDefault(x => x.Name == "teacher").Id;
            List<string> teachers_ID = DB.UserRoles.Where(a => a.RoleId == teacherRoleID).Select(b => b.UserId).Distinct().AsQueryable().ToList();
            List<UserStudent> Teachers = new List<UserStudent>();
            foreach (var teacherID in teachers_ID)
            {
                Teachers.Add(DB.Users.FirstOrDefault(x => x.Id == teacherID));
            }

            return Teachers;
        }


    }
}
