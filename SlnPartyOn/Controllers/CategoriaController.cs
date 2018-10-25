using SlnPartyOn.Models;
using SlnPartyOn.ModelsBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlnPartyOn.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaMB categoriamb = new CategoriaMB();
        public ActionResult CategoriaListarVista()
        {
            return View();
        }
        public ActionResult CategoriaRegistrarVista()
        {
            return View();
        }
        public ActionResult CategoriaEditarVista()
        {
            return View();
        }
        public ActionResult CategoriaListarJson()
        {
            var errormensaje = "";
            var lista = new List<CategoriaModel>();
            try
            {
                lista = categoriamb.CategoriaListar();
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(new { data = lista.ToList(), mensaje = errormensaje });
        }
    }
}