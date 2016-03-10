using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WatchNext.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "TrendingShows", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ShowDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "ShowDetails", id = UrlParameter.Optional }
            );
        }
    }
}
