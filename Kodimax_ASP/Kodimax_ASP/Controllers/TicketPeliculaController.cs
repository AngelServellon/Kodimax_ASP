using Kodimax_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kodimax_ASP.Controllers
{
    public class TicketPeliculaController : Controller
    {
        
        // GET: TicketPelicula
        public ActionResult Index()
        {
            return View();
        }
        
        //Listar las peliculas
        public ActionResult ListaPeliculas()
        {
            using (var db = new KodimaxContext())
            {
                return PartialView(db.Pelicula.ToList());
            }
        }
        //Listar las salas
        public ActionResult ListaSalas()
        {
            using (var db = new KodimaxContext())
            {
                return PartialView(db.Sala.ToList());
            }
        }

        //Obtener precio de sala
        public static double PrecioSala(int id_Sala)
        {
            using (var db= new KodimaxContext())
            {
                return db.Sala.Find(id_Sala).Precio;
            }
        }
        //Obtener nombre de la sala
        public static string NombreSala(int id_Sala)
        {
            using (var db = new KodimaxContext())
            {
                return db.Sala.Find(id_Sala).Nombre.ToUpper();
            }
        }
        //Obtener nombre del empleado
        public static string NombreEmpleado(int id_Empleado)
        {
            using (var db = new KodimaxContext())
            {
                return db.Empleado.Find(id_Empleado).NombreCompleto;
            }
        }
        //Obtener nombre de la pelicula
        public static string NombrePelicula(int id_Pelicula)
        {
            using (var db = new KodimaxContext())
            {
                return db.Pelicula.Find(id_Pelicula).Nombre;
            }
        }

        //Agregar Ticket de Peliculas
        public ActionResult AgregarTicketPelicula(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarTicketPelicula(TicketPelicula tp)
        {
            using (var db = new KodimaxContext())
            {
                tp.Fecha = DateTime.Now;
                tp.SubTotal = (Math.Truncate((PrecioSala(tp.id_sala) * tp.Cantidad) * 100) /100);
                tp.Tax = (Math.Round((tp.SubTotal * 0.3533)*100)/100);
                tp.Total = tp.SubTotal + tp.Tax;
                tp.id_empleado = 4;

                //Cambiar la cantidad de asientos de la sala seleccionada
                Sala sala = db.Sala.Find(tp.id_sala);
                if (sala.Asientos < tp.Cantidad)
                {
                    return RedirectToAction("AgregarTicketPelicula", new { message = "No hay muchos asientos disponibles, por favor reduzca la cantidad" });
                }
                else
                {
                    sala.Asientos = sala.Asientos - tp.Cantidad;
                }
                
                db.TicketPelicula.Add(tp);
                db.SaveChanges();

                return RedirectToAction("Pagar", new { id = tp.Id_TicketPelicula });
                //ViewData["Message"] = tp.Total;
                //return View(tp);
            }
        }
        public ActionResult Pagar(int id)
        {
            using (var db = new KodimaxContext())
            {
                TicketPelicula tp = db.TicketPelicula.Find(id);
                return View(tp);
            }
        }
    }
}