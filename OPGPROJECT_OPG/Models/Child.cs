using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPGPROJECT_OPG.Models
{
    public enum Gender { Male,Female}
    public enum ReportMark {Outstanding,Excellent,Good,Average,BelowAverage,Failed}
    public enum Month {January,February,March,April,May,June,July,August,September,October,November,December}
   
    

    public class Child
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Report> Reports { get; set; }
        public List<FamilyMember> FamilyMembers { get; set; }
    }

    

    

    
}