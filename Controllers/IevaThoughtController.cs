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
        [HttpGet]
        public ActionResult Random()
        {
            var result = GetRandomResult();
            if (result != null)
            return RedirectToRoute("t_redirect", routeValues: new { Id = result.Id });

            return View();
        }
        private IevaThought GetRandomResult() { 
              
            var c = new IevaThoughtsContext();
            Random r = new Random();
            //find a random thought
            //this will get slow without caching
           return c.IevaThoughts.AsEnumerable().ElementAt(r.Next(0, c.IevaThoughts.Count()));
        
        }
        // GET: /IevaThought/
        [HttpGet]
        public ActionResult Details(int? Id)
        {
            IevaThought result = null;
            var c = new IevaThoughtsContext();
            var givenId = Id.GetValueOrDefault();
            if (givenId > 0)
            {

                result = c.IevaThoughts.FirstOrDefault(t => t.Id == givenId);
               if (result == null)
                   return new HttpNotFoundResult("Couldn't find thought " + givenId);
              
                    result.ViewCount++;
                    c.SaveChanges();
  
            }
            else
            {
                if (c.IevaThoughts.Count() >= 1)
                {
                    result = GetRandomResult();
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
            return RedirectToRoute("t_redirect", routeValues: new { Id = t.Id });
            
        }
    }
}
