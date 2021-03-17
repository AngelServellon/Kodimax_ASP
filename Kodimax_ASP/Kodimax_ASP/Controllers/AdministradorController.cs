using Kodimax_ASP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Kodimax_ASP.Controllers
{
    public class AdministradorController : Controller
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["KodimaxContext"].ToString().Split('"')[1];
            con = new SqlConnection(constr);
        }

        // GET: Administrador
        public ActionResult MenuAdministrador()
        {
            return View();
        }

        public ActionResult Reportes()
        {
            return View();
        }

        public ActionResult JsonClientes()
        {
            Conectar();
            List<ClienteCE> clientes = new List<ClienteCE>();

            SqlCommand com = new SqlCommand("select * from Cliente", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                ClienteCE cli = new ClienteCE
                {
                    Id_Cliente = int.Parse(registros["Id_Cliente"].ToString()),
                    Nombres = registros["Nombres"].ToString(),
                    Apellidos = registros["Apellidos"].ToString(),
                    Correo = registros["Correo"].ToString(),
                    Telefono = registros["Telefono"].ToString(),
                    Sexo = registros["Sexo"].ToString(),
                    Fecha_nacimiento = DateTime.Parse(registros["Fecha_nacimiento"].ToString()),
                    Usuario = registros["Usuario"].ToString(),
                    Password = registros["Password"].ToString()

                };
                clientes.Add(cli);
            }
            con.Close();

            string json = JsonConvert.SerializeObject(clientes.ToArray());
            System.IO.File.WriteAllText(@"C:\json\clientes.json", json);

            return RedirectToAction("Reportes");
        }

        public ActionResult JsonEmpleados()
        {
            Conectar();
            List<EmpleadoCE> empleados = new List<EmpleadoCE>();

            SqlCommand com = new SqlCommand("select * from Empleado;", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                EmpleadoCE emp = new EmpleadoCE
                {
                    Id_Empleado = int.Parse(registros["Id_Empleado"].ToString()),
                    Nombres = registros["Nombres"].ToString(),
                    Apellidos = registros["Apellidos"].ToString(),
                    Correo = registros["Correo"].ToString(),
                    Telefono = registros["Telefono"].ToString(),
                    Sexo = registros["Sexo"].ToString(),
                    Fecha_nacimiento = DateTime.Parse(registros["Fecha_nacimiento"].ToString()),
                    Usuario = registros["Usuario"].ToString(),
                    Password = registros["Password"].ToString()

                };
                empleados.Add(emp);
            }
            con.Close();

            string json = JsonConvert.SerializeObject(empleados.ToArray());
            System.IO.File.WriteAllText(@"C:\json\empleados.json", json);

            return RedirectToAction("Reportes");
        }

        public ActionResult JsonPeliculas()
        {
            Conectar();
            List<PeliculaCE> peliculas = new List<PeliculaCE>();

            SqlCommand com = new SqlCommand("select * from Pelicula", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                PeliculaCE pel = new PeliculaCE
                {
                    Id_Pelicula = int.Parse(registros["Id_Pelicula"].ToString()),
                    Nombre = registros["Nombre"].ToString(),
                    Duracion = registros["Duracion"].ToString(),
                    Tipo = registros["Tipo"].ToString()

                };
                peliculas.Add(pel);
            }
            con.Close();

            string json = JsonConvert.SerializeObject(peliculas.ToArray());
            System.IO.File.WriteAllText(@"C:\json\peliculas.json", json);

            return RedirectToAction("Reportes");
        }

        public ActionResult JsonGolosinas()
        {
            Conectar();
            List<GolosinaCE> golosinas = new List<GolosinaCE>();

            SqlCommand com = new SqlCommand("select * from Golosina", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                GolosinaCE golo = new GolosinaCE
                {
                    Id_Golosina = int.Parse(registros["Id_Golosina"].ToString()),
                    Nombre = registros["Nombre"].ToString(),
                    Tipo = registros["Tipo"].ToString(),
                    Precio = double.Parse(registros["Precio"].ToString())

                };
                golosinas.Add(golo);
            }
            con.Close();

            string json = JsonConvert.SerializeObject(golosinas.ToArray());
            System.IO.File.WriteAllText(@"C:\json\golosinas.json", json);

            return RedirectToAction("Reportes");
        }

    }
}