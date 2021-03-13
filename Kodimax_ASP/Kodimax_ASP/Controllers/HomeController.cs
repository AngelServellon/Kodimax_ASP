using Kodimax_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kodimax_ASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password))
            {
                KodimaxContext db = new KodimaxContext();
                var cliente = db.Cliente.FirstOrDefault(e => e.Usuario == usuario && e.Password == password);
                var empleado = db.Empleado.FirstOrDefault(e => e.Usuario == usuario && e.Password == password);
                //si el usuario es diferente de null
                if (cliente != null)
                {
                    //encontramos un usuario con los datos
                    FormsAuthentication.SetAuthCookie(cliente.Usuario, true);
                    return RedirectToAction("MenuCliente", "Cliente");
                }
                else if (empleado != null)
                {
                    FormsAuthentication.SetAuthCookie(empleado.Usuario, true);
                    return RedirectToAction("MenuEmpleado", "Empleado");
                }
                else if (usuario == "admin-max" && password == "@dminM@x")
                {
                    return RedirectToAction("MenuAdministrador", "Administrador");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "No se encontraron tus datos"});

                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Llena los campos para iniciar sesion" });
            }

        }

    }
}