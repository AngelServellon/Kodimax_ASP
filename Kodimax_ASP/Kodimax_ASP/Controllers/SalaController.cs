using Kodimax_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kodimax_ASP.Controllers
{
    public class SalaController : Controller
    {
        // GET: Sala
        public ActionResult Index()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Sala.ToList());
        }

        //Editar sala
        public ActionResult EditarSala(int id)
        {
            try
            {
                using (var db = new KodimaxContext())
                {
                    Sala sala = db.Sala.Find(id);
                    return View(sala);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error - " + ex.Message);
                return View();
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarSala(Sala s)
        {
            try
            {
                using (var db = new KodimaxContext())
                {
                    Sala sala = db.Sala.Find(s.Id_Sala);
                    sala.Nombre = s.Nombre;
                    sala.Precio = s.Precio;
                    sala.Asientos = s.Asientos;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error - " + ex.Message);
                return View();
            }
        }
    }
}