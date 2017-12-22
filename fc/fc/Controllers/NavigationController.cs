using fc.Helpers;
using fc.Models;
using fc.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc.Controllers
{
    public class NavigationController : Controller
    {
        private indproEntities db = new indproEntities();
        private string currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;

        public ActionResult Header()
        {
            return PartialView("~/Views/Navigation/_Header.cshtml");
        }
                
        public ActionResult Footer()
        {
            FooterModelView model = new FooterModelView()
            {
                scelti = getScelti(),
                chisiamo = CommonHelper.getConf("about_short_it", "about_short_en", currentCulture),
                social = db.sy_social.ToList(),
                azienda = CommonHelper.getConf("azienda", "azienda", currentCulture)
            };
           
            return PartialView("~/Views/Navigation/_Footer.cshtml",model);
        }

        private IList<FeaturedModelView> getScelti()
        {
            List<FeaturedModelView> model = new List<FeaturedModelView>();

            var articoli = db.ma_articoli
                .Where(x => x.online == true)
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

            return model;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}