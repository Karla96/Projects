namespace Projekt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recipes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NoServings = c.Int(nullable: false),
                        Description = c.String(),
                        TotalCalories = c.Int(nullable: false),
                        TotalProteins = c.Int(nullable: false),
                        TotalFats = c.Int(nullable: false),
                        TotalCarbos = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "UserId" });
            DropTable("dbo.Recipes");
        }
    }
}
