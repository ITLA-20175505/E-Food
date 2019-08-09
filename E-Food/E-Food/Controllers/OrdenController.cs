using E_Food.Models;
using E_Food.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Food.Controllers
{
    public class OrdenController : Controller
      {
            // GET: Order
            private List<ViewDetalleOrden> detalle;
            private Servicio servicio;
        private List<Servicio> listaServicio;
        private EFood bd = new EFood();
        public ActionResult Index()
        {
            listaServicio = new List<Servicio>();
            listaServicio = bd.Servicios.ToList();
            return View(listaServicio);
        }
            public ActionResult AgregarDetalle(int idServicio, int cantidad, int idOrden)
            {

                // SI NO EXISTEN ITEMS EN Detalle ORDENES, SE CREA UNA NUEVA LISTA
                if (Session["detalleOrden"] == null)
                {
                    detalle = new List<ViewDetalleOrden>();

                    using (EFood bd = new EFood())
                    {
                        var result = bd.buscarServicio(idServicio);
                        servicio = new Servicio();
                        servicio = result.FirstOrDefault();
                    }
                    detalle.Add(new ViewDetalleOrden(idOrden, servicio, cantidad));
                    Session["detalleOrden"] = detalle;
                }
                // SI EXISTE LA LISTA DETALLE ORDENES, SE TOMA COMO REFERENCIA DE LA SESSION "DETALLEORDEN"
                else
                {
                    detalle = (List<ViewDetalleOrden>)Session["detalleOrden"];
                    int existe = getIndex(idServicio);
                    // SI NO EXISTE EL ARTICULO EN EL DETALLE, SE AGREGA
                    if (existe == -1)
                    {
                        using (EFood bd = new EFood())
                        {
                            var result = bd.buscarServicio(idServicio);
                            servicio = new Servicio();
                            servicio = result.FirstOrDefault();
                        }
                        detalle.Add(new ViewDetalleOrden(idOrden, servicio, cantidad));
                        // SI EXISTE, SOLAMENTE SE SUMA LA CANTIDAD
                    }
                    else
                        detalle[existe].Cantidad = cantidad++;
                    Session["detalleOrden"] = detalle;
                }
                return View();
            }
            private int getIndex(int idServicio)
            {
                detalle = (List<ViewDetalleOrden>)Session["detalleOrden"];
                for (int i = 0; i < detalle.Count; i++)
                {
                    if (detalle[i].servicio.idServicio == idServicio)
                        return i;

                }
                return -1;

            }
            public ActionResult borrarDetalle(int idServicio)
            {
                detalle = (List<ViewDetalleOrden>)Session["detalleOrden"];
                detalle.RemoveAt(getIndex(idServicio));
                return View("AgregarDetalle");
            }
        }

    }