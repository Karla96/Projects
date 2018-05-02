using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.DAL.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        //public virtual ICollection<Diary> Diaries { get; set; }

        public Meal()
        {
            Foods = new List<Food>();
            //Diaries = new List<Diary>();
        }

    }
}