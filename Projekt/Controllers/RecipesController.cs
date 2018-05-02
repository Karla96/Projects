using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Projekt.DAL.Models;

namespace Projekt.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
       
        private Kontekst db = new Kontekst();

        
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();

            var recipes = db.Recipes.Include(r => r.User);

            return View(recipes.Where(p => p.UserId == user)    
                .ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }
        
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NoServings,Description,TotalCalories,TotalProteins,TotalFats,TotalCarbos,UserId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                User currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

                currentUser.Recipes.Add(recipe);
                db.SaveChanges();
                return View("Details", recipe);
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", recipe.UserId);
            return View(recipe);
        }

        public ActionResult AddFood(int id)
        {
            ViewModelForMeal viewModel = new ViewModelForMeal();
            viewModel.MealId = id;
            this.DropDownList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddFoodToMeal(ViewModelForMeal viewModel)//int selected, int id)
        {
            this.DropDownList();
            
            var kontekst = new Kontekst();
            Food result = kontekst.Foods
                            .FirstOrDefault(p => p.Id == viewModel.SelectedId);
            
            Recipe resultRecipe = new Recipe();
            resultRecipe = kontekst.Recipes
                        .Where(p => p.Id == viewModel.MealId)
                        .FirstOrDefault();
            
            resultRecipe.TotalCalories += result.Calories * resultRecipe.NoServings;
            resultRecipe.TotalCarbos += Convert.ToInt32(result.Carbs * resultRecipe.NoServings);
            resultRecipe.TotalFats += Convert.ToInt32(result.Fat * resultRecipe.NoServings);
            resultRecipe.TotalProteins += Convert.ToInt32(result.Protein * resultRecipe.NoServings);
            
            resultRecipe.Foods.Add(result);

            kontekst.SaveChanges();
            kontekst.Dispose();


            return View("Details", resultRecipe);

        }

        public void DropDownList()
        {
            using (var kontekst = new Kontekst())
            {
                var possibleFoods = kontekst.Foods
                    .ToList();

                var selectItems = new List<System.Web.Mvc.SelectListItem>();

                var listItem = new SelectListItem();
                listItem.Text = "- choose -";
                listItem.Value = "";
                selectItems.Add(listItem);

                foreach (var food in possibleFoods)
                {
                    listItem = new SelectListItem();
                    listItem.Text = food.Name;
                    listItem.Value = food.Id.ToString();
                    listItem.Selected = false;
                    selectItems.Add(listItem);
                }
                ViewBag.PossibleFoods = selectItems;

            }
        }

            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Recipe recipe = db.Recipes.Find(id);
                if (recipe == null)
                {
                    return HttpNotFound();
                }
                ViewBag.UserId = new SelectList(db.Users, "Id", "Name", recipe.UserId);
                return View(recipe);
            }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NoServings,Description,TotalCalories,TotalProteins,TotalFats,TotalCarbos,UserId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                User currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

                db.Entry(recipe).State = EntityState.Modified;

                currentUser.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", recipe.UserId);
            return View(recipe);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        

    }
}
