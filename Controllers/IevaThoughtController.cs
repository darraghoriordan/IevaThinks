using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IevaThinks.Models;

namespace IevaThinks.Controllers
{
    [Authorize]
    public class IevaThoughtController : Controller
    {
        //
        // GET: /IevaThought/
        [HttpGet]
        public IevaThought GetOne(int Id)
        {
            var c = new IevaThoughtsContext();            
            var it = c.IevaThoughts.FirstOrDefault(t => t.Id == Id);
            if (it != null)
            {
                it.ViewCount++;
                c.SaveChanges();
            }
            return it;
        }
        [HttpGet]
        public IEnumerable<IevaThought> GetTop(int count)
        {
            var c = new IevaThoughtsContext();
            var tList = c.IevaThoughts.OrderByDescending(t => t.ViewCount).Take(count);

            return tList;
        }
        [HttpPost]
        public ActionResult Save(string txtMessage)
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
            return null;
        }
    }
}
