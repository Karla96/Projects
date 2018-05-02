using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.DAL.Models
{
    public class Progress
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public int UserDailyCalories { get; set; }
        public double Weight { get; set; }
    }
}