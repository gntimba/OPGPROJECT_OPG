using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OPGPROJECT_OPG.Models
{
    public class Context : IdentityDbContext<LoginUser>
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Email> Emails { get; set; }



        public Context()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static Context Create()
        {
            return new Context();
        }
    }
}