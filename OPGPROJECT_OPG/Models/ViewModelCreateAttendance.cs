using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPGPROJECT_OPG.Models
{
    public class ViewModelCreateAttendance
    {
        public List<Child>  Children{ get; set; }
        public Attendance Attendance { get; set; }
        public string ChildID { get; set; }

        public ViewModelCreateAttendance()
        {
            Attendance = new Attendance();
            Children = new List<Child>();
        }
    }
}