using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPGPROJECT_OPG.Models
{
    public enum AttendanceStatus {Present,Late,Absent} 
    public class Attendance
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Child Child { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
        public string CheckInTime { get; set; }
        public string PickUpTime { get; set; }


        public string GetNameAndLastName()
        {
            return Child.Name + " " + Child.Surname;
        }
    }
}