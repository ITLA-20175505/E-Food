using E_Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Food.Controllers
{
    public class OrdenController : Controller
    {
        // GET: Orden
        public ActionResult Index()
        {
            List<Detalle_Orden> listaDetalleOrden;
            using (EFood bd = new EFood())
            {
                listaDetalleOrden = (from d in bd.TipoABs
                               select new ListaTabla
                               {
                                   idTipoAB = d.idTipo,
                                   Nombre = d.Nombre
                               }).ToList();
            }
            return View(listaTipoAB);
        }
    }
}