using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc.Areas.Admin.Controllers
{
    public class RichiesteController : Controller
    {
        // GET: Admin/Richieste
        public ActionResult Index()
        {
            return View();
        }
    }
}