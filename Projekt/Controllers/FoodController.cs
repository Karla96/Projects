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
    public class FoodController : Controller
    {
        public Kontekst db = new Kontekst();
        
        public ActionResult Index()
        {
            return View(db.Foods.ToList());
        }

        [HttpPost]
        public ActionResult IndexAjax(FoodFilter f)
        {
            var dataquery = db.Foods.ToList();
            if (!string.IsNullOrWhiteSpace(f.Name))
                dataquery = dataquery.Where(p => p.Name.Contains(f.Name)).ToList();
            return PartialView("_IndexTable", dataquery);
        }
        
        public ActionResult FilterForm()
        {
            return PartialView("_FoodFilter");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }
        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Portion,ServingSize,Calories,Carbs,Fat,Protein")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(food);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Portion,ServingSize,Calories,Carbs,Fat,Protein")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(food);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }


        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteAjax(int id)
        {

            var model = db.Foods
                .FirstOrDefault(p => p.Id == id);

            db.Entry(model).State = EntityState.Deleted;
            db.SaveChanges();

            return Json(new { isSuccess = true });
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
