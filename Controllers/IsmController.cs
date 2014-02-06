using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsmsWebApplication.Models;
using IsmsWebApplication.DataContext;

namespace IsmsWebApplication.Controllers
{

    public class IsmController : Controller
    {
        private IsmDataContext db = new IsmDataContext();

        [HttpGet]
        public ActionResult Random()
        {
            var result = GetRandomResult();
            ViewBag.Title = result.IsmConfiguration.TargetName + "ism";
            if (result != null)
                return RedirectToRoute("t_redirect", routeValues: new { Id = result.Id });

            return View();
        }
        private Ism GetRandomResult()
        {
            Random r = new Random();
            //find a random thought
            //this will get slow without caching
            return db.Isms.Include(i => i.IsmConfiguration).AsEnumerable().ElementAt(r.Next(0, db.Isms.Count()));

        }
        // GET: /Isms/
        [HttpGet]
        public ActionResult Details(int? Id)
        {
            Ism result = null;

            var givenId = Id.GetValueOrDefault();
            if (givenId > 0)
            {

                result = db.Isms.Include(i=>i.IsmConfiguration).FirstOrDefault(t => t.Id == givenId);
                if (result == null)
                    return new HttpNotFoundResult("Couldn't find an ism " + givenId);

            

            }
            else
            {
                if (db.Isms.Count() >= 1)
                {
                    result = GetRandomResult();
                }
                else
                {
                    //nada
                    result = new Ism();
                    result.IsmConfiguration = db.IsmConfigurations.First();
                }

            }

            if (result.Id > 0)
            {
                result.ViewCount++;
                db.SaveChanges();
            }

            ViewBag.Title = result.IsmConfiguration.TargetName + "ism";
            return View(result);
        }
        [HttpGet]
        public ActionResult List(int count)
        {

            var tList = db.Isms.OrderByDescending(t => t.ViewCount).Take(count);

            return View("List", tList);
        }

        [HttpGet]
        public ActionResult Create(int? configid)
        {
            IsmConfiguration firstConfig;
            if (configid.HasValue)
            {
                firstConfig = db.IsmConfigurations.First(ic => ic.Id == configid.Value);
            }
            else
            {
                firstConfig = db.IsmConfigurations.OrderBy(ic => ic.Id).First();
            }

            var t = new Ism()
           {
               IsmText = "???",
               IsmConfiguration = firstConfig
       
           };

            var ismConfigs = db.IsmConfigurations.OrderBy(ic => ic.Id).AsEnumerable().Select(ic => new SelectListItem() { Text = ic.TargetName, Value = ic.Id.ToString() }).ToList();
            ismConfigs.First(ic => ic.Value == firstConfig.Id.ToString()).Selected = true;
            ViewBag.IsmConfigurations = ismConfigs;
            return View(t);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(string txtMessage, int IsmConfigurationId)
        {
            var ic = db.IsmConfigurations.First(c => c.Id == IsmConfigurationId);
            var t = new Ism()
            {
                CreatedOn = DateTime.UtcNow,
                IsmText = txtMessage,
                Username = this.User.Identity.Name,
                SharedOn = Consants.BaselineDate,
                IsmConfiguration = ic
            };
            db.Isms.Add(t);
            db.SaveChanges();
            return RedirectToRoute("t_redirect", routeValues: new { Id = t.Id });

        }
    }
}
