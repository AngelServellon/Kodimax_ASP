using Kodimax_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kodimax_ASP.Controllers
{
    public class TicketGolosinaController : Controller
    {
        // GET: TicketGolosina
        public ActionResult Index()
        {
            return View();
        }

        //Listar las golosinas
        public ActionResult ListaGolosinas()
        {
            using (var db = new KodimaxContext())
            {
                return PartialView(db.Golosina.ToList());
            }
        }

        //Obtener Precio de la golosina
        public static double PrecioGolosina(int id_Golosina)
        {
            using (var db = new KodimaxContext())
            {
                return db.Golosina.Find(id_Golosina).Precio;
            }
        }
        //Obtener nombre del empleado
        public static string NombreEmpleado(int id_Empleado)
        {
            using (var db = new KodimaxContext())
            {
                if (id_Empleado == null)
                {
                    return "nombre";
                }
                else
                {
                    return db.Empleado.Find(id_Empleado).NombreCompleto;
                }
            }
        }

        //Agregar ticket de golosina
        public ActionResult AgregarTicketGolosina()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarTicketGolosina(TicketGolosina tg)
        {
            using (var db = new KodimaxContext())
            {
                tg.Fecha = DateTime.Now;
                tg.SubTotal = (Math.Truncate((PrecioGolosina(tg.id_golosina) * tg.Cantidad) * 100) / 100);
                tg.Tax = (Math.Round((tg.SubTotal * 0.0453) * 100) / 100);
                tg.Total = tg.SubTotal + tg.Tax;
                tg.id_empleado = 1;

                db.TicketGolosina.Add(tg);
                db.SaveChanges();

                ViewData["Message"] = tg.Total;
                return View(tg);
            }
        }
    }
}