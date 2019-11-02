using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPGPROJECT_OPG.Models
{
    public class ClassRoom
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public User Teacher { get; set; }
        public List<Child> Children { get; set; }
    }
}