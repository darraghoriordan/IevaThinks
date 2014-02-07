using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsmsWebApplication.Models;
using IsmsWebApplication.DataContext;

namespace IsmsWebApplication.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class IsmConfigurationController : Controller
    {
        private IsmDataContext db = new IsmDataContext();

        //
        // GET: /IsmConfiguration/

        public ActionResult Index()
        {
            return View(db.IsmConfigurations.ToList());
        }

        //
        // GET: /IsmConfiguration/Details/5

        public ActionResult Details(int id = 0)
        {
            IsmConfiguration ismconfiguration = db.IsmConfigurations.Find(id);
            if (ismconfiguration == null)
            {
                return HttpNotFound();
            }
            return View(ismconfiguration);
        }

        //
        // GET: /IsmConfiguration/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /IsmConfiguration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IsmConfiguration ismconfiguration)
        {
            ismconfiguration.CreatedOn = DateTime.UtcNow;
            ismconfiguration.Username = User.Identity.Name;

            if (ModelState.IsValid)
            {
                db.IsmConfigurations.Add(ismconfiguration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ismconfiguration);
        }

        //
        // GET: /IsmConfiguration/Edit/5
        public ActionResult Edit(int id = 0)
        {
            IsmConfiguration ismconfiguration = db.IsmConfigurations.Find(id);
            if (ismconfiguration == null)
            {
                return HttpNotFound();
            }
            return View(ismconfiguration);
        }

        //
        // POST: /IsmConfiguration/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IsmConfiguration ismconfiguration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ismconfiguration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ismconfiguration);
        }

        //
        // GET: /IsmConfiguration/Delete/5
        public ActionResult Delete(int id = 0)
        {
            IsmConfiguration ismconfiguration = db.IsmConfigurations.Find(id);
            if (ismconfiguration == null)
            {
                return HttpNotFound();
            }
            return View(ismconfiguration);
        }

        //
        // POST: /IsmConfiguration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IsmConfiguration ismconfiguration = db.IsmConfigurations.Find(id);
            db.IsmConfigurations.Remove(ismconfiguration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}