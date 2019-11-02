namespace OPGPROJECT_OPG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lvel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "User_ID", "dbo.Users");
            DropIndex("dbo.Children", new[] { "User_ID" });
            RenameColumn(table: "dbo.Children", name: "User_ID", newName: "userID");
            AlterColumn("dbo.Children", "userID", c => c.Int(nullable: true));
            CreateIndex("dbo.Children", "userID");
            AddForeignKey("dbo.Children", "userID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "userID", "dbo.Users");
            DropIndex("dbo.Children", new[] { "userID" });
            AlterColumn("dbo.Children", "userID", c => c.Int());
            RenameColumn(table: "dbo.Children", name: "userID", newName: "User_ID");
            CreateIndex("dbo.Children", "User_ID");
            AddForeignKey("dbo.Children", "User_ID", "dbo.Users", "ID");
        }
    }
}
