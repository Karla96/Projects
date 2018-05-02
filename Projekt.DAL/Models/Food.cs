using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.DAL.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Range(1, 1000, ErrorMessage = "Portion must be number between 1 and 1000")]
        [Required(ErrorMessage = "This field is required")]
        public int Portion { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public double ServingSize { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public double Carbs { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public double Fat { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public double Protein { get; set; }
        
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }

        public Food()
        {
            Meals = new List<Meal>();
            Recipes = new List<Recipe>();
        }
    }
}