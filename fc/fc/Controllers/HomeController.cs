using fc.App_Start;
using fc.Helpers;
using fc.Models;
using fc.ModelViews;
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
        private indproEntities db = new indproEntities();
        private string currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;

        public virtual ActionResult Index()
        {            
            return View();
        }
        
        public ActionResult Category()
        {
            List<CategoryModelView> model = new List<CategoryModelView>();

            var categorie = db.mc_cat_merc
                .Where(x=> x.livello == 1)
                .OrderBy(x => Guid.NewGuid())
                .Take(12);

            foreach (var x in categorie)
            {
                model.Add(new CategoryModelView
                {
                    id_categoria = x.id_categoria,
                    ads = x.ma_articoli.Count(c=> c.online == true),
                    img = CommonHelper.getImg(x, Url.Content("~/public/media/ads/")),
                    descrizione = currentCulture == "en" ? x.descrizione_en : x.descrizione_it
                });
            }

            return PartialView("~/Views/Home/_Category.cshtml", model.OrderBy(x=> x.descrizione));
        }

        public ActionResult Search()
        {
            List<CategoryModelView> model = new List<CategoryModelView>();

            var categorie = db.mc_cat_merc
                .Where(x => x.livello == 1);            

            foreach (var x in categorie)
            {
                model.Add(new CategoryModelView
                {
                    id_categoria = x.id_categoria,   
                    descrizione = currentCulture == "en" ? x.descrizione_en : x.descrizione_it
                });
            }

            return PartialView("~/Views/Home/_Search.cshtml", model.OrderBy(x => x.descrizione));
        }
                
        public ActionResult LastProducts()
        {
            List<FeaturedModelView> model = new List<FeaturedModelView>();

            var articoli = db.ma_articoli
                .Where(x=> x.online == true)
                .OrderBy(x => Guid.NewGuid())
                .Take(8);

            foreach (var x in articoli)
            {
                model.Add(new FeaturedModelView
                {
                    id_articolo = x.id_articolo,
                    img = CommonHelper.getImgArt(x, Url.Content("~/public/media/ads/")),
                    articolo = x.articolo
                });
            }

            return PartialView("~/Views/Home/_LastProducts.cshtml", model);
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
            CounterModelView model = new CounterModelView()
            {
                countFind = db.ma_articoli_richieste.Count(x=> x.online == true),
                countSell = db.ma_articoli.Count(x=> x.online == true),
                countMembers = db.AspNetUsers.Count()
            };

            return PartialView("~/Views/Home/_Counter.cshtml", model);
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
   
}