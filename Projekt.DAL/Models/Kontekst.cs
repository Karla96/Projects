using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Projekt.DAL.Models
{
    public class Kontekst : IdentityDbContext<User>
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Progress> Progress { get; set; }

        public Kontekst()
           : base("Kontekst", throwIfV1Schema: false)
        {
        }

        public static Kontekst Create()
        {
            return new Kontekst();
        }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/


    }
}