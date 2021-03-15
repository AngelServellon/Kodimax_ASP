using Kodimax_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kodimax_ASP.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult MenuEmpleado()
        {
            return View();
        }

        public ActionResult Index()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Empleado.ToList());
        }

        //Agregar
        public ActionResult AgregarEmpleado()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarEmpleado(Empleado e)
        {
            try
            {
                using (var db = new KodimaxContext())
                {
                    db.Empleado.Add(e);
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

        //Eliminar
        public ActionResult EliminarEmpleado(int id)
        {
            using (var db = new KodimaxContext())
            {
                Empleado emp = db.Empleado.Find(id);
                db.Empleado.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}