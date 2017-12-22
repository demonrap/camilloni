using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc.Areas.Admin.Controllers
{
    public class UtentiController : Controller
    {
        // GET: Admin/Utenti
        public ActionResult Index()
        {
            return View();
        }
    }
}