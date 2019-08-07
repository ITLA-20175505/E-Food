using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Food.Models
{
    public class Orden
    {
        public int idOrden { get; set; }
        public Mesa mesa { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }

    }
}