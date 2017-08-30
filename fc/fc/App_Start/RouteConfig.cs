using System.Web.Mvc;
using System.Web.Routing;

namespace fc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "category-it", 
                url: "{lang}/categorie/{name}/{id}", 
                defaults: new { controller = "Category", action = "Index", name = UrlParameter.Optional, id = UrlParameter.Optional },
                constraints: new { lang = "it"}
            );

            routes.MapRoute(
                name: "category-en",
                url: "{lang}/categories/{name}/{id}",
                defaults: new { controller = "Category", action = "Index", name = UrlParameter.Optional, id = UrlParameter.Optional },
                constraints: new { lang = "en" }
            );

            routes.MapRoute(
                name: "detail-it",
                url: "{lang}/dettagli/{name}/{id}",
                defaults: new { controller = "Detail", action = "Index", name = UrlParameter.Optional, id = UrlParameter.Optional },
                constraints: new { lang = "it" }
            );

            routes.MapRoute(
                name: "faq-it",
                url: "{lang}/faq",
                defaults: new { controller = "Home", action = "Faq" },
                constraints: new { lang = "it" }
            );

            routes.MapRoute(
                name: "faq-en",
                url: "{lang}/faq",
                defaults: new { controller = "Home", action = "Faq" },
                constraints: new { lang = "en" }
            );

            routes.MapRoute(
                name: "about-it",
                url: "{lang}/chi-siamo",
                defaults: new { controller = "Home", action = "About" },
                constraints: new { lang = "it" }
            );

            routes.MapRoute(
                name: "about-en",
                url: "{lang}/about",
                defaults: new { controller = "Home", action = "About" },
                constraints: new { lang = "en" }
            );

            routes.MapRoute(
               name: "Language",
               url: "{lang}/{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               constraints: new { lang = @"it|en" }
           );

            routes.MapRoute(
                name: "faq",
                url: "faq",
                defaults: new { controller = "Home", action = "Faq" }
            );

            routes.MapRoute(
                name: "categories",
                url: "categories/{name}/{id}",
                defaults: new { controller = "Category", action = "Index", name = UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "detail",
               url: "detail/{name}/{id}",
               defaults: new { controller = "Detail", action = "Index", name = UrlParameter.Optional, id = UrlParameter.Optional }
           );

            routes.MapRoute(
             name: "about",
             url: "about",
             defaults: new { controller = "Home", action = "About" }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
