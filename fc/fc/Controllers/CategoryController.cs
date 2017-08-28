using fc.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc.Controllers
{
    [Localization("en")]
    public class CategoryController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }
    }
}