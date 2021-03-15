using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kodimax_ASP.Models
{
    public class GolosinaCE
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public double Precio { get; set; }
    }
    [MetadataType(typeof(GolosinaCE))]
    public partial class Golosina
    {

    }
}