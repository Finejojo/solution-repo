﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TodoApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute(
                name: "Register",
                url: "register/{Register}",
                defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Login",
                url: "login/{Login}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
