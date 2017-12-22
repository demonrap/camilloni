using fc.Helpers;
using fc.Models;
using fc.ModelViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fc.Areas.Admin.Controllers
{
    public class VenditeController : Controller
    {
        private const int REC_X_PAGINA = 25;
        private indproEntities db = new indproEntities();

        public ActionResult Index()
        {
            return View();
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
                        categoria =  x.mc_cat_merc.descrizione_it,
                        data_pubblicazione = x.data_pubblicazione.ToString("yyyy-MM-dd"),                        
                        id_categoria = x.id_categoria,
                        ore = x.ore_di_lavoro.ToString(),
                        peso = x.peso.ToString(),
                        produttore = x.produttore,
                        conta_visite = x.ma_articoli_view.visite.ToString(),
                        conta_img = x.ma_articoli_img.Count().ToString(),
                        img = CommonHelper.getImgArt(x, Url.Content("~/public/media/ads/")),
                        descrizione_en = x.descrizione_en,
                        descrizione_it = x.descrizione_it,
                        id_utente = x.id_utente,
                        online = x.online,
                        prezzo_di_vendita = CommonHelper.setDecimal(x.prezzo_di_vendita),
                        prezzo_richiesto = CommonHelper.setDecimal(x.prezzo_richiesto),
                        valuta = x.valuta,
                        venduto = x.venduto
                    };
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }        

        private IQueryable<ma_articoli> GetArticoli(FilterModelView filtri)
        {
            var model = from m in db.ma_articoli select m;

            if (!string.IsNullOrEmpty(filtri.cat))
                model = model.Where(x => x.id_categoria.Contains(filtri.cat));

            if (!string.IsNullOrEmpty(filtri.key))
                model = CommonHelper.LikeResult(model, filtri.key, "descrizione_it");

            if (!filtri.online)
                model = model.Where(x => x.online == false);
            else
                model = model.Where(x => x.online == true);

            return model;
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult Create(ma_articoli model)
        {
            DbObject obj = new DbObject();
            obj.db_obj_ack = "KO";
            obj.db_obj_message = "Attenzione i campi obbligatori non sono stati validati";

            if (ModelState.IsValid)
            {
                try
                {
                    db.ma_articoli.Add(model);
                    db.SaveChanges();
                    obj.db_obj_ack = "OK";
                }
                catch (Exception ex)
                {
                    obj.db_obj_ack = "KO";
                    obj.db_obj_message = ex.Message;
                }
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult Edit(ma_articoli model)
        {
            DbObject obj = new DbObject();
            obj.db_obj_ack = "KO";
            obj.db_obj_message = "Attenzione i campi obbligatori non sono stati validati";

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    obj.db_obj_ack = "OK";
                }
                catch (Exception ex)
                {
                    obj.db_obj_ack = "KO";
                    obj.db_obj_message = ex.Message;
                }
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult Delete(ma_articoli model)
        {
            DbObject obj = new DbObject();
            try
            {
                var _obj = db.ma_articoli.Find(model.id_articolo);
                db.ma_articoli.Remove(_obj);
                db.SaveChanges();
                obj.db_obj_ack = "OK";
            }
            catch (Exception ex)
            {
                obj.db_obj_ack = "KO";
                obj.db_obj_message = ex.Message;
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}