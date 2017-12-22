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
    public class CategorieController : Controller
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
            int count = GetCategorie(filtri).Count();
            filtri.rec_number = count;
            filtri.rec_x_pagina = REC_X_PAGINA;
            filtri.pag_number = Math.Ceiling(1.0 * count / REC_X_PAGINA);

            return Json(filtri, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult getContenutoPagina(FilterModelView filtri)
        {
            var result = GetCategorie(filtri)
                .ToList()
                .Select(x =>
                {
                    return new CategorieModelView()
                    {
                        livello = CommonHelper.setInt(x.livello),
                        chiave = x.chiave,
                        descrizione_en = x.descrizione_en,
                        descrizione_it = x.descrizione_it,
                        id_categoria = x.id_categoria,
                        id_categoria_padre = x.id_categoria_padre
                    };
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private IQueryable<mc_cat_merc> GetCategorie(FilterModelView filtri)
        {
            var model = from c in db.mc_cat_merc select c;

            if (!string.IsNullOrEmpty(filtri.cat))
                model = CommonHelper.LikeResult(model, filtri.cat, "descrizione_it");

            return model;
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult Create(mc_cat_merc model)
        {
            DbObject obj = new DbObject();
            obj.db_obj_ack = "KO";
            obj.db_obj_message = "Attenzione i campi obbligatori non sono stati validati";

            if (ModelState.IsValid)
            {
                try
                {
                    db.mc_cat_merc.Add(model);
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
        public JsonResult Edit(mc_cat_merc model)
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
        public JsonResult Delete(mc_cat_merc model)
        {
            DbObject obj = new DbObject();
            try
            {
                var _obj = db.mc_cat_merc.Find(model.id_categoria);
                db.mc_cat_merc.Remove(_obj);
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