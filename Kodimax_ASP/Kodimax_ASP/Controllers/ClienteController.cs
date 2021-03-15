using Kodimax_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kodimax_ASP.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult MenuCliente()
        {
            return View();
        }
        public ActionResult Index()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Cliente.ToList());
        }
        public ActionResult EliminarCliente(int id)
        {
            using (var db = new KodimaxContext())
            {
                Cliente cli = db.Cliente.Find(id);
                db.Cliente.Remove(cli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


    }
}