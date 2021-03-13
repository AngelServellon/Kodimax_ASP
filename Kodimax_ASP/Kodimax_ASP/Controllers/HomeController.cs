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

        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(string Nombres, string Apellidos, string Correo, string Telefono, string Sexo, DateTime Fecha_nacimiento, string Usuario, string Password, string Codigo)
        {
            if (Codigo == "emp-max")
            {
                using (var db = new KodimaxContext())
                {
                    Empleado emp = new Empleado();
                    emp.Nombres = Nombres;
                    emp.Apellidos = Apellidos;
                    emp.Correo = Correo;
                    emp.Telefono = Telefono;
                    emp.Sexo = Sexo;
                    emp.Fecha_nacimiento = Fecha_nacimiento;
                    emp.Usuario = Usuario;
                    emp.Password = Password;

                    db.Empleado.Add(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                using (var db = new KodimaxContext())
                {
                    Cliente cli = new Cliente();
                    cli.Nombres = Nombres;
                    cli.Apellidos = Apellidos;
                    cli.Correo = Correo;
                    cli.Telefono = Telefono;
                    cli.Sexo = Sexo;
                    cli.Fecha_nacimiento = Fecha_nacimiento;
                    cli.Usuario = Usuario;
                    cli.Password = Password;

                    db.Cliente.Add(cli);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}