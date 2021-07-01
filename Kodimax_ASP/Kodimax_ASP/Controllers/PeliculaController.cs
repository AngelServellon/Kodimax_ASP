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
    public class PeliculaController : Controller
    {
        // GET: Pelicula
        public ActionResult Index()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Pelicula.ToList());
        }
        //------------------------------------------------------------------
        //SECCION EMPLEADOS

        //Agregar pelicula
        public ActionResult AgregarPelicula()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarPelicula(Pelicula p)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            WebImage image = new WebImage(FileBase.InputStream);

            p.Imagen = image.GetBytes();

            if (ModelState.IsValid)
            {
                using (var db = new KodimaxContext())
                {
                    db.Pelicula.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("MenuEmpleado", "Empleado");
                }
            }
            else
            {
                return View();
            }            
        }
        
        //Eliminar pelicula
        public ActionResult VerPeliculas()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Pelicula.ToList());
        }
        public ActionResult EliminarPelicula(int id)
        {
            using (var db = new KodimaxContext())
            {
                Pelicula pel = db.Pelicula.Find(id);
                db.Pelicula.Remove(pel);
                db.SaveChanges();
                return RedirectToAction("VerPeliculas");
            }
        }
        //------------------------------------------------------------------
        //SECCION Administrador
        //Agregar pelicula
        public ActionResult AgregarPeliculaAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarPeliculaAdmin(Pelicula p)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            WebImage image = new WebImage(FileBase.InputStream);

            p.Imagen = image.GetBytes();

            if (ModelState.IsValid) {
                using (var db = new KodimaxContext())
                {
                    db.Pelicula.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("MenuAdministrador", "Administrador");
                }
            }
            else
            {
                return View();
            }
        }
        //Eliminar pelicula
        public ActionResult VerPeliculasAdmin()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Pelicula.ToList());
        }
        public ActionResult EliminarPeliculaAdmin(int id)
        {
            using (var db = new KodimaxContext())
            {
                Pelicula pel = db.Pelicula.Find(id);
                db.Pelicula.Remove(pel);
                db.SaveChanges();
                return RedirectToAction("VerPeliculasAdmin");
            }
        }

        public ActionResult getImage(int id) //Poner la imagen
        {
            using (var db = new KodimaxContext())
            {
                Pelicula peli = db.Pelicula.Find(id);
                byte[] byteImage = peli.Imagen;

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