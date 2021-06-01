using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTable.Service
{
    public class VeiwLogic
    {
        //05.11.2021%205%3A42%3A36
        //5.14.2021%258%253A45%253A5
        public static string GetCorrectDate()
        {
            DateTime Date = DateTime.Now;
            return (Date.Month + "." + Date.Day + "." + Date.Year + "%" + Date.Hour + "%3A" + Date.Minute + "%3A" + Date.Second);
        }
    }
}
