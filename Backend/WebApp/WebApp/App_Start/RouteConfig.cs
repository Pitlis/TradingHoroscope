using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //public pages
            routes.MapRoute(
                name: "Index",
                url: "Index",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Faq",
                url: "faq",
                defaults: new { controller = "Home", action = "Faq" }
            );
            routes.MapRoute(
                name: "Products",
                url: "products",
                defaults: new { controller = "Home", action = "Products" }
            );
            routes.MapRoute(
                name: "Info",
                url: "info/{zodiac}",
                defaults: new { controller = "Home", action = "Info", zodiac = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Edit",
                url: "edit",
                defaults: new { controller = "Admin", action = "AdminPage"}
            );
            routes.MapRoute(
                name: "Login",
                url: "edit/login",
                defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
                name: "Logout",
                url: "edit/logout",
                defaults: new { controller = "Account", action = "LogOff" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
