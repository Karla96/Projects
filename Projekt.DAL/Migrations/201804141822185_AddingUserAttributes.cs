namespace Projekt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "CurrentWeight", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "GoalWeight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GoalWeight");
            DropColumn("dbo.AspNetUsers", "CurrentWeight");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
