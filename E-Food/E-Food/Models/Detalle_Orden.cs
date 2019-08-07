using DotLiquid.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace E_Food.Models
{
    public class Detalle_Orden
    {
        public Orden orden { get; set; }
        public Servicio servicio { get; set; }
        public int cantidad { get; set; }
        
    }
}