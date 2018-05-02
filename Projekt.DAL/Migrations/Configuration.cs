namespace Projekt.DAL.Migrations
{
    using Projekt.DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projekt.DAL.Models.Kontekst>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Projekt.DAL.Models.Kontekst context)
        {
            
             context.Foods.AddOrUpdate(
                 p => p.Name,
                  new Food { Name = "Egg", Portion = 63, ServingSize = 1, Calories = 75, Carbs = 0, Fat = 5, Protein = 6 },
                  new Food { Name = "Chicken breast", Portion = 100, ServingSize = 1, Calories = 110, Carbs = 0, Fat = 1, Protein = 23 },
                  new Food { Name = "Tomato", Portion = 100, ServingSize = 1, Calories = 18, Carbs = 4, Fat = 0, Protein = 1 },
                  new Food { Name = "Low fat cheese", Portion = 100, ServingSize = 1, Calories = 78, Carbs = 4, Fat = 2, Protein = 11 },
                  new Food { Name = "Broccoli", Portion = 100, ServingSize = 1, Calories = 34, Carbs = 6, Fat = 0, Protein = 3 },
                  new Food { Name = "Almonds", Portion = 20, ServingSize = 1, Calories = 115, Carbs = 4, Fat = 10, Protein = 4 },
                  new Food { Name = "Raspberries", Portion = 100, ServingSize = 1, Calories = 53, Carbs = 12, Fat = 0, Protein = 1 },
                  new Food { Name = "Mushrooms", Portion = 100, ServingSize = 1, Calories = 28, Carbs = 5, Fat = 0, Protein = 2 },
                  new Food { Name = "Spaghetti (wholemeal)", Portion = 50, ServingSize = 1, Calories = 180, Carbs = 33, Fat = 1, Protein = 6 },
                  new Food { Name = "Rice (wholemeal)", Portion = 40, ServingSize = 1, Calories = 139, Carbs = 20, Fat = 1, Protein = 3 },
                  new Food { Name = "Banana", Portion = 100, ServingSize = 1, Calories = 89, Carbs =23, Fat = 0, Protein = 1 },
                  new Food { Name = "Tuna", Portion = 100, ServingSize = 1, Calories = 91, Carbs = 0, Fat = 0, Protein = 21 },
                  new Food { Name = "Toast (wholemeal)", Portion = 25, ServingSize = 1, Calories = 64, Carbs = 11, Fat = 1, Protein = 2 },
                  new Food { Name = "Oatmeal", Portion = 40, ServingSize = 1, Calories = 144, Carbs = 25, Fat = 2, Protein = 5 },
                  new Food { Name = "Almond milk", Portion = 100, ServingSize = 1, Calories = 28, Carbs = 4, Fat = 1, Protein = 1 }
                );
        }
 
    }
}