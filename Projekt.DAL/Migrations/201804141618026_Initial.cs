namespace Projekt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Portion = c.Int(nullable: false),
                        ServingSize = c.Double(nullable: false),
                        Calories = c.Int(nullable: false),
                        Carbs = c.Double(nullable: false),
                        Fat = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Food");
        }
    }
}
