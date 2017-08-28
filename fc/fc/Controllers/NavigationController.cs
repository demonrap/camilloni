using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc.Controllers
{
    public class NavigationController : Controller
    {
        public ActionResult Header()
        {
            return PartialView("~/Views/Navigation/_Header.cshtml");
        }

        public ActionResult Footer()
        {
            return PartialView("~/Views/Navigation/_Footer.cshtml");
        }
    }
}