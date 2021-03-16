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
                return db.Sala.Find(id_Sala).Nombre;
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
        //Obtener nombre de la pelicula
        public static string NombrePelicula(int id_Pelicula)
        {
            using (var db = new KodimaxContext())
            {
                return db.Pelicula.Find(id_Pelicula).Nombre;
            }
        }

        //Agregar Ticket de Peliculas
        public ActionResult AgregarTicketPelicula()
        {
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
                tp.id_empleado = 1;

                db.TicketPelicula.Add(tp);
                db.SaveChanges();
                
                ViewData["Message"] = tp.Total;
                return View(tp);
            }
        }
        
        //
        
    }
}