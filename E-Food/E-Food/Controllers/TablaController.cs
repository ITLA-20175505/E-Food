using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Food.Models;
using E_Food.Models.ViewModels;

namespace E_Food.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListaTabla> listaTipoAB;
            using(EFoodEntities bd = new EFoodEntities())
            {
               listaTipoAB = (from d in bd.TipoABs
                                select new ListaTabla
                                {
                                    idTipoAB = d.idTipo,
                                    Nombre = d.nombreAB
                                }).ToList();
            }
            return View(listaTipoAB);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaTipoAB model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(EFoodEntities bd = new EFoodEntities())
                    {
                        var tabla = new TipoAB();
                        tabla.nombreAB = model.Nombre;

                        bd.TipoABs.Add(tabla);
                        bd.SaveChanges();
                    }
                    return Redirect("/");
                }
                return View(model);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        }
    }
