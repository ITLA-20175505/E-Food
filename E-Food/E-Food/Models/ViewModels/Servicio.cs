using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations

namespace E_Food.Models.ViewModels
{
    public class Servicio
    {
        [Display(Name = "ID Servicio")]
        public int idServicio { get; set; }
        [Required]
        [Display(Name = "Tipo AB")]
        public TipoAB tipoAB { get; set; }
        [Required]
        [Display(Name = "Tipo Servicio")]
        public TipoServicio tipoServicio{get;set;}
        [Required]
        [Display(Name = "Nombre")]
        public string nombre;
    }
}