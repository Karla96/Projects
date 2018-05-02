using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekt.DAL.Models
{
    public class DiaryDate
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Meal))]
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        
    }
}