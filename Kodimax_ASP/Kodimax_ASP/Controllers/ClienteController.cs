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
        public ActionResult Cartelera()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Pelicula.ToList());
        }
    }
}