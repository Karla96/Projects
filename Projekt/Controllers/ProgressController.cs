using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Projekt.DAL.Models;

namespace Projekt.Controllers
{
    public class ProgressController : Controller
    {
        private Kontekst db = new Kontekst();

        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();

            var progress = db.Progress.Where(p => p.UserId == user).ToList();

            return View(progress);
        }
    }  
}
