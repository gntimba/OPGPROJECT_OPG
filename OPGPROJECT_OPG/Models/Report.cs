using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPGPROJECT_OPG.Models
{
    public class Report
    {
        public int ID { get; set; }
        public Month Month { get; set; }
        public ReportMark SelfManagement { get; set; }
        public ReportMark SelfAwareness { get; set; }
        public ReportMark SocialAwareness { get; set; }
        public ReportMark RelationshipSkills { get; set; }
        public ReportMark ResponsibleDecisionMaking { get; set; }
    }
}