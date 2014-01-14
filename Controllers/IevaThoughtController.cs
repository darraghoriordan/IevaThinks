using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IevaThink.Models;

namespace IevaThink.Controllers
{
    
    public class IevaThoughtController : Controller
    {
        //
        // GET: /IevaThought/
        [HttpGet]
        public ActionResult Details(int? Id)
        {
            IevaThought result = null;
            var c = new IevaThoughtsContext();
            if (Id.GetValueOrDefault() > 0)
            {

                var it = c.IevaThoughts.FirstOrDefault(t => t.Id == Id);
                if (it != null)
                {
                    it.ViewCount++;
                    c.SaveChanges();
                }
            }
            else
            {
                if (c.IevaThoughts.Count() >= 1)
                {
                    Random r = new Random();
                    //find a random thought
                    //this will get slow without caching
                    result = c.IevaThoughts.AsEnumerable().ElementAt(r.Next(0, c.IevaThoughts.Count()));
                }
                else
                { 
                    //nada
                    result = new IevaThought();
                }
            }
            return View(result);
        }
        [HttpGet]
        public ActionResult List(int count)
        {
            var c = new IevaThoughtsContext();
            var tList = c.IevaThoughts.OrderByDescending(t => t.ViewCount).Take(count);

            return View("List", tList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var t = new IevaThought()
           {
               Thought = "???"
           };
            return View(t);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(string txtMessage)
        {
            var c = new IevaThoughtsContext();
            var t = new IevaThought()
            {
                CreatedOn = DateTime.UtcNow,
                Thought = txtMessage,
                Username = this.User.Identity.Name,
                SharedOn = Consants.BaselineDate
            };
            c.IevaThoughts.Add(t);
            c.SaveChanges();
            return View("Details", t);
        }
    }
}
