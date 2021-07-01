using Kodimax_ASP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kodimax_ASP.Controllers
{
    public class GolosinaController : Controller
    {
        // GET: Golosina
        public ActionResult Index()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Golosina.ToList());
        }
        //---------------------------------------------------------------
        //EMPLEADO

        //Agregar golosina
        public ActionResult AgregarGolosina()
        {
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarGolosina(Golosina g)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            WebImage image = new WebImage(FileBase.InputStream);
            
            g.Imagen = image.GetBytes();

            if (ModelState.IsValid)
            {
                using (var db = new KodimaxContext())
                {
                    db.Golosina.Add(g);
                    db.SaveChanges();
                    return RedirectToAction("MenuEmpleado", "Empleado");
                }
            }
            else
            {
                return View();
            }
        }
        
        //Eliminar golosina
        public ActionResult VerGolosinas()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Golosina.ToList());
        }
        public ActionResult EliminarGolosina(int id)
        {
            try
            {
                using (var db = new KodimaxContext())
                {
                    Golosina gol = db.Golosina.Find(id);
                    db.Golosina.Remove(gol);
                    db.SaveChanges();
                    return RedirectToAction("VerGolosinas");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error - " + ex.Message);
                return View();
            }
            
        }

        //Editar Golosinas
        public ActionResult VerGolosinasEd()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Golosina.ToList());
        }
        public ActionResult EditarGolosina(int id)
        {
            try
            {
                using (var db = new KodimaxContext())
                {
                    Golosina golo = db.Golosina.Find(id);
                    return View(golo);
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
        public ActionResult EditarGolosina(Golosina g)
        {
          
            try
            {
                using (var db = new KodimaxContext())
                {
                    Golosina golo = db.Golosina.Find(g.Id_Golosina);
                    golo.Nombre = g.Nombre;
                    golo.Tipo = g.Tipo;
                    golo.Precio = g.Precio;

                    db.SaveChanges();
                    return RedirectToAction("VerGolosinasEd");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error - " + ex.Message);
                return View();
            }
        }
        //---------------------------------------------------------------
        //ADMINISTRADOR
        //Agregar golosina
        public ActionResult AgregarGolosinaAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarGolosinaAdmin(Golosina g)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            WebImage image = new WebImage(FileBase.InputStream);

            g.Imagen = image.GetBytes();

            if (ModelState.IsValid)
            {
                using (var db = new KodimaxContext())
                {
                    db.Golosina.Add(g);
                    db.SaveChanges();
                    return RedirectToAction("MenuAdministrador", "Administrador");
                }
            }
            else
            {
                return View();
            }
        }

        //Eliminar golosina
        public ActionResult VerGolosinasAdmin()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Golosina.ToList());
        }
        public ActionResult EliminarGolosinaAdmin(int id)
        {
            try
            {
                using (var db = new KodimaxContext())
                {
                    Golosina gol = db.Golosina.Find(id);
                    db.Golosina.Remove(gol);
                    db.SaveChanges();
                    return RedirectToAction("VerGolosinasAdmin");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error - " + ex.Message);
                return View();
            }

        }

        //Editar Golosinas
        public ActionResult VerGolosinasEdAdmin()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Golosina.ToList());
        }
        public ActionResult EditarGolosinaAdmin(int id)
        {
            try
            {
                using (var db = new KodimaxContext())
                {
                    Golosina golo = db.Golosina.Find(id);
                    return View(golo);
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
        public ActionResult EditarGolosinaAdmin(Golosina g)
        {

            try
            {
                using (var db = new KodimaxContext())
                {
                    Golosina golo = db.Golosina.Find(g.Id_Golosina);
                    golo.Nombre = g.Nombre;
                    golo.Tipo = g.Tipo;
                    golo.Precio = g.Precio;

                    db.SaveChanges();
                    return RedirectToAction("VerGolosinasEdAdmin");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error - " + ex.Message);
                return View();
            }
        }


        public ActionResult getImage(int id) //Poner la imagen
        {
            using (var db = new KodimaxContext())
            {
                Golosina golo = db.Golosina.Find(id);
                byte[] byteImage = golo.Imagen;

                MemoryStream memoryStream = new MemoryStream(byteImage);
                Image image = Image.FromStream(memoryStream);

                memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Jpeg);
                memoryStream.Position = 0;

                return File(memoryStream, "image/jpg");
            }

        }
    }
}