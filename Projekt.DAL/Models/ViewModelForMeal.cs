using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.DAL.Models
{
    public class ViewModelForMeal
    {
        public ViewModelForMeal()
        {
            Foods = new List<Food>();
            F = new Food();
        }
        public int MealId { get; set; }
        public List<Food> Foods { get; set; }
        public int SelectedId { get; set; }
        public Food F { get; set; }


    }
}