using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPGPROJECT_OPG.Models
{
    public class ViewModelAddChild
    {
        public List<User> Users { get; set; }
        public Child Child { get; set; }
        public int UserID { get; set; }
    }
}