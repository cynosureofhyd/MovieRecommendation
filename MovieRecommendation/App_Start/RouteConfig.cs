﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieRecommendation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Movies", action = "Get", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SearchString",
                url: "{controller}/{action}/{searchString}",
                defaults: new { controller = "Home", action = "Search", searchString = UrlParameter.Optional }
            );
        }
    }
}
