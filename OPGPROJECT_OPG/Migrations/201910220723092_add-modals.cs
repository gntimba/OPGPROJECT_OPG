namespace OPGPROJECT_OPG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        AttendanceStatus = c.Int(nullable: false),
                        Child_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Children", t => t.Child_ID)
                .Index(t => t.Child_ID);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        ClassRoom_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoom_ID)
                .Index(t => t.ClassRoom_ID);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Cellphone = c.String(),
                        Gender = c.Int(nullable: false),
                        Child_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Children", t => t.Child_ID)
                .Index(t => t.Child_ID);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        SelfManagement = c.Int(nullable: false),
                        SelfAwareness = c.Int(nullable: false),
                        SocialAwareness = c.Int(nullable: false),
                        RelationshipSkills = c.Int(nullable: false),
                        ResponsibleDecisionMaking = c.Int(nullable: false),
                        Child_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Children", t => t.Child_ID)
                .Index(t => t.Child_ID);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Teacher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Teacher_ID)
                .Index(t => t.Teacher_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassRooms", "Teacher_ID", "dbo.Users");
            DropForeignKey("dbo.Children", "ClassRoom_ID", "dbo.ClassRooms");
            DropForeignKey("dbo.Attendances", "Child_ID", "dbo.Children");
            DropForeignKey("dbo.Reports", "Child_ID", "dbo.Children");
            DropForeignKey("dbo.FamilyMembers", "Child_ID", "dbo.Children");
            DropIndex("dbo.ClassRooms", new[] { "Teacher_ID" });
            DropIndex("dbo.Reports", new[] { "Child_ID" });
            DropIndex("dbo.FamilyMembers", new[] { "Child_ID" });
            DropIndex("dbo.Children", new[] { "ClassRoom_ID" });
            DropIndex("dbo.Attendances", new[] { "Child_ID" });
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Reports");
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.Children");
            DropTable("dbo.Attendances");
        }
    }
}
