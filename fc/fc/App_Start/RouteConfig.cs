using System.Web.Mvc;
using System.Web.Routing;

namespace fc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");           

            routes.MapRoute(
                name: "category-it", 
                url: "{lang}/categoria", 
                defaults: new { controller = "Category", action = "Index" },
                constraints: new { lang = "it"}
            );

            routes.MapRoute(
               name: "Language",
               url: "{lang}/{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               constraints: new { lang = @"it|en" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
