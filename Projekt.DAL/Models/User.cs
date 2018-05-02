using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Projekt.DAL.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double CurrentWeight { get; set; }
        public double GoalWeight { get; set; }
        public int Height { get; set; }
        public int DailyCalories { get; set; }
        public int Gender { get; set; }
        public int LevelOfActivity { get; set; }

        //public virtual ICollection<Diary> Diaries { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }

        public User()
        {
            //Diaries = new List<Diary>();
            Recipes = new List<Recipe>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}