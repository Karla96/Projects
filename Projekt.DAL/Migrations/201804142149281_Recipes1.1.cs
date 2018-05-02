namespace Projekt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recipes11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeFoods",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Food_Id })
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_Id, cascadeDelete: true)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Food_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeFoods", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.RecipeFoods", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeFoods", new[] { "Food_Id" });
            DropIndex("dbo.RecipeFoods", new[] { "Recipe_Id" });
            DropTable("dbo.RecipeFoods");
        }
    }
}
