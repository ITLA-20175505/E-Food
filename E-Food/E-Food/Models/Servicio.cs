using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Food.Models
{
    public class Servicio
    {
        public int idServicio { get; set; }
        public TipoAB tipoAB { get; set; }
        public TipoServicio tipoServicio { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public DateTime tiempo { get; set; }

    }
}