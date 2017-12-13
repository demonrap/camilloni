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
                name: "post-it",
                url: "{lang}/vendi/{id}",
                defaults: new { controller = "post", action = "create", id = UrlParameter.Optional },
                constraints: new { lang = "it" }
            );

            routes.MapRoute(
                name: "post-en",
                url: "{lang}/sell/{id}",
                defaults: new { controller = "post", action = "create", id = UrlParameter.Optional },
                constraints: new { lang = "en" }
            );

            routes.MapRoute(
                name: "user-it",
                url: "{lang}/utente/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = "it" }
            );

            routes.MapRoute(
                name: "user-en",
                url: "{lang}/user/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = "en" }
            );

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
                name: "howto-it",
                url: "{lang}/come",
                defaults: new { controller = "Home", action = "HowTo" },
                constraints: new { lang = "it" }
            );

            routes.MapRoute(
                name: "howto-en",
                url: "{lang}/how-to",
                defaults: new { controller = "Home", action = "HowTo" },
                constraints: new { lang = "en" }
            );

            routes.MapRoute(
                name: "contact-it",
                url: "{lang}/contatti",
                defaults: new { controller = "Home", action = "Contact" },
                constraints: new { lang = "it" }
            );

            routes.MapRoute(
                name: "contact-en",
                url: "{lang}/contact",
                defaults: new { controller = "Home", action = "Contact" },
                constraints: new { lang = "en" }
            );

            routes.MapRoute(
                name: "about-lang",
                url: "{lang}/about",
                defaults: new { controller = "Home", action = "About" },
               constraints: new { lang = @"it|en" }
            );

            routes.MapRoute(
               name: "cookie-lang",
               url: "{lang}/privacy-cookie-policy",
               defaults: new { controller = "Home", action = "Cookie" },
               constraints: new { lang = @"it|en" }
           );

            routes.MapRoute(
                name: "faq-lang",
                url: "{lang}/faq",
                defaults: new { controller = "Home", action = "Faq" },
               constraints: new { lang = @"it|en" }
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
                 name: "cookie",
                 url: "privacy-cookie-policy",
                 defaults: new { controller = "Home", action = "Cookie" }
             );

            routes.MapRoute(
                 name: "contact",
                 url: "contact",
                 defaults: new { controller = "Home", action = "Contact" }
             );

            routes.MapRoute(
                name: "howto",
                url: "how-to",
                defaults: new { controller = "Home", action = "HowTo" }
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
             name: "post",
             url: "sell/{id}",
             defaults: new { controller = "Post", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
