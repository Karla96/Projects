namespace Projekt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFoodModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DailyCalories", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DailyCalories");
            DropColumn("dbo.AspNetUsers", "Height");
        }
    }
}
