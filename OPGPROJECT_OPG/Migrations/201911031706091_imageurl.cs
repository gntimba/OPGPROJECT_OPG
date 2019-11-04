namespace OPGPROJECT_OPG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "imageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Children", "imageUrl");
        }
    }
}
