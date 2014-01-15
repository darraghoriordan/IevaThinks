using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IevaThink
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "random_redirect",
            url: "random",
            defaults: new { controller = "IevaThought", action = "Random" }
            );
            routes.MapRoute(
         name: "t_redirect",
         url: "thought/{id}",
         defaults: new { controller = "IevaThought", action = "Details", id = UrlParameter.Optional }
     );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "IevaThought", action = "Details", id = UrlParameter.Optional }
            );

        }
    }
}