using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kodimax_ASP.Models
{
    public class EmpleadoCE
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public System.DateTime Fecha_nacimiento { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required] 
        public string Password { get; set; }
    }
    [MetadataType(typeof(EmpleadoCE))]
    public partial class Empleado
    {
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }
}