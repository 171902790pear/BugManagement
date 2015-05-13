using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BugManagement.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Projects",
                url: "Projects",
                defaults: new { controller = "Project", action = "List" }
            );

            routes.MapRoute(
                name: "SignIn",
                url: "SignIn/{username}",
                defaults: new { controller = "Account", action = "SignIn", username = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Signup",
                url: "Signup",
                defaults: new { controller = "Account", action = "Signup"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Signup", id = UrlParameter.Optional }
            );
        }
    }
}