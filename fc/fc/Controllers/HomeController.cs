using fc.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace fc.Controllers
{
    //[Localization("en")]
    public class HomeController : Controller
    {
                
        public virtual ActionResult Index()
        {            
            return View();
        }
        
        public ActionResult Category()
        {
            return PartialView("~/Views/Home/_Category.cshtml");
        }
                
        public ActionResult Search()
        {
            return PartialView("~/Views/Home/_Search.cshtml");
        }
                
        public ActionResult LastProducts()
        {
            return PartialView("~/Views/Home/_LastProducts.cshtml");
        }

        
        public ActionResult Services()
        {
            return PartialView("~/Views/Home/_Services.cshtml");
        }
                
        public ActionResult Locations()
        {
            return PartialView("~/Views/Home/_Locations.cshtml");
        }
                
        public ActionResult Counter()
        {
            return PartialView("~/Views/Home/_Counter.cshtml");
        }
                
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
                
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cookie()
        {
            return View();
        }

        public ActionResult HowTo()
        {            
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

    }
}