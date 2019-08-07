using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Food.Models
{
    public class TipoServicio
    {
        public int idTipoServicio { get; set; }
        public TipoAB tipoAB { get; set; }
        public string nombre { get; set; }

    }
}