using fc.Helpers;
using fc.Models;
using fc.ModelViews;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace fc.Areas.Admin.Controllers
{
    public class UtentiController : Controller
    {
        private const int REC_X_PAGINA = 25;
        private ApplicationDbContext db;
        private UserManager<ApplicationUser> userManager;

        public UtentiController()
        {
            db = new ApplicationDbContext();
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult getContenutoPagina(FilterModelView filtri)
        {
            var model = db.Users.Where(x => x.Email != "sbelviso@gmail.com")
                .ToList()
                .Select(x => {
                    return new UtentiView()
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        AccessFailedCount = x.AccessFailedCount,
                        LockoutEnabled = x.LockoutEnabled,
                        Roles = GetRoles(x.Id)
                    };
                });

            if (!string.IsNullOrEmpty(filtri.username))
                model = model.Where(x => x.UserName.Contains(filtri.username.ToLower()));

            model = model
                .OrderBy(x => x.Id)
                .Skip(filtri.page_number * REC_X_PAGINA)
                .Take(REC_X_PAGINA);

            return Json(model, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult getPaginatore(FilterModelView filtri)
        {
            var model = db.Users.Where(x => x.Email != "sbelviso@gmail.com")
                 .ToList()
                 .Select(x => {
                     return new UtentiView()
                     {
                         Id = x.Id,
                         UserName = x.UserName
                     };
                 });

            if (!string.IsNullOrEmpty(filtri.username))
                model = model.Where(x => x.UserName.Contains(filtri.username));

            int count = model.Count();

            filtri.rec_number = count;
            filtri.rec_x_pagina = REC_X_PAGINA;
            filtri.pag_number = Math.Ceiling(1.0 * count / REC_X_PAGINA);

            return Json(filtri, JsonRequestBehavior.AllowGet);
        }

        private string GetRoles(string id)
        {
            string ruoli = string.Empty;
            var model = userManager.GetRoles(id);
            foreach (var r in model)
            {
                ruoli = "<span class=\"label label-danger\">" + r + "</span>&nbsp;" + ruoli;
            }
            return ruoli;
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public async Task<JsonResult> create(RegisterViewModel model)
        {
            DbObject obj = new DbObject();
            string error = "Non è stato possibile registrare il nuovo utente verifica i campi e riprova.";

            Regex rgx = new Regex(@"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$");
            if (!rgx.IsMatch(model.Password))
            {
                error = "La password non è conforme deve essere di almeno 8 caratteri contenere numeri e lettere di cui una maiuscola e caratteri speciali.";
                ModelState.AddModelError("", error);
                obj.db_obj_message = error;

            }
            else if (string.Compare(model.Password, model.ConfirmPassword) != 0)
            {
                error = "Le password inserite non coincidono.";
                ModelState.AddModelError("", error);
                obj.db_obj_message = error;
            }


            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email.ToLower(), Email = model.Email.ToLower() };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "UTENTE");
                    string GetCurrentUrl = Request.Url.GetLeftPart(UriPartial.Authority);

                    //invia la mail di benvenuto
                    string destinatario = model.Email;
                    string emaildestinatario = model.Email;
                    string oggetto = "Dettagli account per NewAge Finanze";
                    string corpo = "<p>Grazie per esserti registrato sul nostro portale.<br/>" +
                        "Puoi accedere al portale <a href='" + GetCurrentUrl + "'>http://www.newageintimo.net</a> usando le seguenti credenziali:</p>" +
                        "<p>username: " + model.Email + "<br/>" +
                        "password: " + model.Password + "</p>";
                    string firma = "<strong>-- NewAge Finanze Team</strong>";

                    UtilsHelper.InviaLaMail(destinatario, emaildestinatario, null, oggetto, corpo, firma);
                    obj.db_obj_ack = "OK";
                }
                obj.db_obj_ack = "KO";
                obj.db_obj_message = AddErrors(result);
            }
            else
            {
                obj.db_obj_ack = "KO";
                obj.db_obj_message = error;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public async Task<JsonResult> ResetPasswordUser(UtentiView model)
        {
            DbObject obj = new DbObject();
            var user = await userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                string password = UtilsHelper.RandomString(8);
                await userManager.RemovePasswordAsync(model.Id);
                await userManager.AddPasswordAsync(model.Id, password);

                string GetCurrentUrl = Request.Url.GetLeftPart(UriPartial.Authority);

                string destinatario = model.UserName;
                string emaildestinatario = model.UserName;
                string oggetto = "Reset account NewAge Finanze";
                string corpo = "<p>La richiesta per il reset della password è stata effettuata.<br/>" +
                    "Potrai accedere usando le nuove credenziali:</p>" +
                    "<p>password: " + password + "</p>";
                string firma = "<strong>-- NewAge Finanze Team</strong>";

                UtilsHelper.InviaLaMail(destinatario, emaildestinatario, null, oggetto, corpo, firma);
                obj.db_obj_ack = "OK";
            }
            else
            {
                obj.db_obj_ack = "KO";
                obj.db_obj_message = "Non è stato possibile effettuare il reset della password per l'utente selezionato";
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult EditRole(UtentiView model)
        {
            var ruoli = new EditRuoliView()
            {
                Id = model.Id,
                Email = model.UserName,
                ruoli = getRuoli(model)
            };

            return Json(ruoli, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult SaveRole(EditRuoliView model)
        {
            DbObject obj = new DbObject();
            try
            {
                foreach (var x in model.ruoli)
                {
                    if (userManager.IsInRole(model.Id, x.Name))
                        userManager.RemoveFromRole(model.Id, x.Name);

                    if (x.check)
                        userManager.AddToRole(model.Id, x.Name);
                }
                obj.db_obj_ack = "OK";
            }
            catch (ArgumentException ex)
            {
                obj.db_obj_ack = "KO";
                obj.db_obj_message = ex.Message;
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        private IList<RuoliView> getRuoli(UtentiView model)
        {
            var ruoli = db.Roles
                .ToList()
                .Select(x =>
                {
                    return new RuoliView()
                    {
                        Name = x.Name,
                        check = getCheck(x.Name, model)
                    };
                })
                .ToList();

            return ruoli;
        }

        private bool getCheck(string name, UtentiView model)
        {
            bool check = false;
            foreach (var x in userManager.GetRoles(model.Id))
            {
                if (x == name)
                    check = true;
            }
            return check;
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public async Task<JsonResult> Delete(UtentiView model)
        {
            DbObject obj = new DbObject();

            if (string.IsNullOrEmpty(model.Id))
            {
                obj.db_obj_ack = "KO";
                obj.db_obj_message = "Non è stato possibie eliminare il record corrente.";
            }

            var user = await userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                obj.db_obj_ack = "OK";
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        private string AddErrors(IdentityResult result)
        {
            string model = null;

            foreach (var error in result.Errors)
            {
                model = model + error + " ";
            }
            return model;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            userManager.Dispose();
            base.Dispose(disposing);
        }

    }
}