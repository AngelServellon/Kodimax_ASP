using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kodimax_ASP.Models
{
    public class PeliculaCE
    {
        public int Id_Pelicula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Duracion { get; set; }
        [Required]
        public string Tipo { get; set; }
        
    }

    [MetadataType(typeof(PeliculaCE))]
    public partial class Pelicula
    {

    }
}