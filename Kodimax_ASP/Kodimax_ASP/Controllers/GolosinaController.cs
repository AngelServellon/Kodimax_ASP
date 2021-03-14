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

        //Agregar pelicula
        public ActionResult AgregarGolosina()
        {
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarGolosina(Golosina g)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            //HttpFileCollectionBase collection = Request.Files;

            WebImage image = new WebImage(FileBase.InputStream);
            
            g.Imagen = image.GetBytes();

            if (ModelState.IsValid)
            {
                using (var db = new KodimaxContext())
                {
                    db.Golosina.Add(g);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
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

        //Eliminar pelicula
        public ActionResult VerGolosinas()
        {
            KodimaxContext db = new KodimaxContext();
            return View(db.Golosina.ToList());
        }
        public ActionResult EliminarGolosina(int id)
        {
            using (var db = new KodimaxContext())
            {
                Golosina gol = db.Golosina.Find(id);
                db.Golosina.Remove(gol);
                db.SaveChanges();
                return RedirectToAction("VerGolosinas");
            }
        }
    }
}