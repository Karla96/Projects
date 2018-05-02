using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt.DAL.Models;

namespace Projekt.Controllers
{
    public class MealController : Controller
    {
        private Kontekst db = new Kontekst();

        public ActionResult Index()
        {
            return View(db.Meals.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Meals.Add(meal);
                db.SaveChanges();
                return View("Details", meal);
            }

            return View(meal);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddFood(int id)
        {
            ViewModelForMeal viewModel = new ViewModelForMeal();
            viewModel.MealId = id;
            this.DropDownList();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddFoodToMeal(ViewModelForMeal viewModel)//int selected, int id)
        {
            this.DropDownList();
            
            var kontekst = new Kontekst();
            Food result = kontekst.Foods
                            .FirstOrDefault(p => p.Id == viewModel.SelectedId);
            viewModel.Foods.Add(result);

            Meal resultMeal = new Meal();
            resultMeal = kontekst.Meals
                        .Where(p => p.Id == viewModel.MealId)
                        .FirstOrDefault();

            resultMeal.Foods.Add(result);

            kontekst.SaveChanges();
            kontekst.Dispose();


            return View("Details", resultMeal);

        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meal);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meal meal = db.Meals.Find(id);
            db.Meals.Remove(meal);
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
    }
}
