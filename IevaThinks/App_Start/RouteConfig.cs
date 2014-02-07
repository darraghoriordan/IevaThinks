using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IsmsWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "random_redirect",
                url: "random",
                defaults: new { controller = "Ism", action = "Random" }
            );

           // routes.MapRoute(
           //     name: "t_redirect",
           //     url: "ism/{id}",
          //      defaults: new { controller = "Ism", action = "Details", id = UrlParameter.Optional }
          //  );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ism", action = "Details", id = UrlParameter.Optional }
            );

        }
    }
}