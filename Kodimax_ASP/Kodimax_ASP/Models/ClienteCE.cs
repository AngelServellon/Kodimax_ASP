using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kodimax_ASP.Models
{
    public class ClienteCE
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public System.DateTime Fecha_nacimiento { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
    [MetadataType(typeof(ClienteCE))]
    public partial class Cliente
    {
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }
}