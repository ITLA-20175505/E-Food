using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace E_Food.Models.ViewModels
{
    public class DetalleOrden
    {
        [Required]
        [Display(Name = "Orden")]
        public Orden orden { get; set; }
        [Required]
        [Display(Name ="Servicio")]
        public Servicio servicio { get; set; }
        [Required]
        [Display(Name ="Cantidad")]
        public int Cantidad { get; set; }
    }
}