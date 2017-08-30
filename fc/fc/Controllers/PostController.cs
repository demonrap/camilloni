using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc.Controllers
{
    public class PostController : Controller
    {     
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                //lo mando alla pagina di registrazione o login
                return RedirectToAction("Login", "Account");
            
            return RedirectToAction("Create");
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}