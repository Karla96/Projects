using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekt.DAL.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoServings { get; set; }
        public string Description { get; set; }
        public int TotalCalories { get; set; }
        public int TotalProteins { get; set; }
        public int TotalFats { get; set; }
        public int TotalCarbos { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        public Recipe()
        {
            Foods = new List<Food>();
        }

    }
}