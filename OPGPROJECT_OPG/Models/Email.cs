using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPGPROJECT_OPG.Models
{
    public class Email
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
        public Child Child { get; set; }
    }
}