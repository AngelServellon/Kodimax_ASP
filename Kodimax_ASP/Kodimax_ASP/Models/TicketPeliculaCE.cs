using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kodimax_ASP.Models
{
    public class TicketPeliculaCE
    {
        public System.DateTime Fecha { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        [Required]
        [Display(Name = "Pelicula")]
        public int id_pelicula { get; set; }
        [Required]
        [Display(Name = "Sala")]
        public int id_sala { get; set; }
        
        
    }
    [MetadataType(typeof(TicketPeliculaCE))]
    public partial class TicketPelicula
    {

    }
}