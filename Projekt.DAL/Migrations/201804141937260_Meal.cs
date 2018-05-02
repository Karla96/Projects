namespace Projekt.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Meal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MealFoods",
                c => new
                    {
                        Meal_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meal_Id, t.Food_Id })
                .ForeignKey("dbo.Meals", t => t.Meal_Id, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_Id, cascadeDelete: true)
                .Index(t => t.Meal_Id)
                .Index(t => t.Food_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealFoods", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.MealFoods", "Meal_Id", "dbo.Meals");
            DropIndex("dbo.MealFoods", new[] { "Food_Id" });
            DropIndex("dbo.MealFoods", new[] { "Meal_Id" });
            DropTable("dbo.MealFoods");
            DropTable("dbo.Meals");
        }
    }
}
