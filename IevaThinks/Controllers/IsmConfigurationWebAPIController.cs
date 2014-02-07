using IsmsWebApplication.DataContext;
using IsmsWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IsmsWebApplication.Controllers
{
    public class IsmConfigurationWebAPIController : ApiController
    {
        private IsmDataContext db = new IsmDataContext();
        public IsmConfigurationWebAPIController() { 
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/ismconfigurationwebapi/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            
            IsmConfiguration ismconfiguration = (IsmConfiguration)db.IsmConfigurations.Find(id);
            if (ismconfiguration == null)
            {
                return NotFound();
            }

            return Ok(ismconfiguration);
        }

    }
}
