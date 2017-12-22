using fc.App_Start;
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
    //[Localization("en")]
    public class CategoryController : Controller
    {
        private const int REC_X_PAGINA = 10;
        private indproEntities db = new indproEntities();
        private string currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
      

        public ActionResult Index(FilterModelView filtri)
        {            
            return View(filtri);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult getPaginatore(FilterModelView filtri)
        {
            int count = GetArticoli(filtri).Count();
            filtri.rec_number = count;
            filtri.rec_x_pagina = REC_X_PAGINA;
            filtri.pag_number = Math.Ceiling(1.0 * count / REC_X_PAGINA);

            return Json(filtri, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult getContenutoPagina(FilterModelView filtri)
        {   
            var result = GetArticoli(filtri)
                .ToList()
                .Select(x => 
                {
                    return new ItemModelView()
                    {
                        anno = x.anno_produzione.ToString(),
                        articolo = x.articolo,
                        id_articolo = x.id_articolo,
                        categoria = currentCulture == "en" ? x.mc_cat_merc.descrizione_en : x.mc_cat_merc.descrizione_it,
                        data_pubblicazione = x.data_pubblicazione.ToString("yyyy-MM-dd"),
                        descrizione = currentCulture == "en" ? x.descrizione_en : x.descrizione_it,
                        id_categoria = x.id_categoria,
                        ore = x.ore_di_lavoro.ToString(),
                        peso = x.peso.ToString(),
                        produttore = x.produttore,
                        conta_visite = x.ma_articoli_view.visite.ToString(),
                        conta_img = x.ma_articoli_img.Count().ToString(),
                        img = CommonHelper.getImgArt(x, Url.Content("~/public/media/ads/"))
                    };
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IQueryable<ma_articoli> GetArticoli(FilterModelView filtri)
        {
            string descrizioneLike = currentCulture == "en" ? "descrizione_en" : "descrizione_it";
            var model = from m in db.ma_articoli where m.online == true & m.venduto == false select m;

            if (!string.IsNullOrEmpty(filtri.cat))
                model = model.Where(x => x.id_categoria.Contains(filtri.cat));

            if (!string.IsNullOrEmpty(filtri.key))
                model = CommonHelper.LikeResult(model, filtri.key, descrizioneLike);
            return model;
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

            return PartialView("~/Views/Category/_Search.cshtml", model.OrderBy(x => x.descrizione));
        }

        public ActionResult Advertisement()
        {
            ma_articoli articoli = db.ma_articoli
                .Where(x=> x.online == true & x.venduto == false)
               .OrderBy(x => Guid.NewGuid())
               .Take(1)
               .FirstOrDefault();

            FeaturedModelView model = new FeaturedModelView();

            if(articoli != null)
            {
                model.articolo = articoli.articolo;
                model.id_articolo = articoli.id_articolo;
                model.img = CommonHelper.getImgArt(articoli, Url.Content("~/public/media/ads/"));
            }

            return PartialView("~/Views/Category/_Advertisement.cshtml", model);
        }

        public ActionResult LastProduct()
        {
            List<FeaturedModelView> model = new List<FeaturedModelView>();
            var articoli = db.ma_articoli
                .Where(x=> x.online == true & x.venduto == false)
               .OrderBy(x => Guid.NewGuid())
               .Take(6);

            foreach (var x in articoli)
            {
                model.Add(new FeaturedModelView
                {
                    id_articolo = x.id_articolo,
                    img = CommonHelper.getImgArt(x, Url.Content("~/public/media/ads/")),
                    articolo = x.articolo
                });
            }

            return PartialView("~/Views/Category/_LastProduct.cshtml", model);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}