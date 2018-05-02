namespace Projekt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFoodModified1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LevelOfActivity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LevelOfActivity");
            DropColumn("dbo.AspNetUsers", "Gender");
        }
    }
}
