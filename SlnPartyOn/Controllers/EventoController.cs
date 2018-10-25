using SlnPartyOn.Models;
using SlnPartyOn.ModelsBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlnPartyOn.Controllers
{
    public class EventoController : Controller
    {
        private EventoMB eventomb = new EventoMB();
        public ActionResult EventoUsuarioListarVista()
        {
            return View("~/Views/Evento/EventoUsuarioListarVista.cshtml");
        }
        public ActionResult EventoUsuarioRegistrarVista()
        {
            return View("~/Views/Evento/EventoUsuarioRegistrarVista.cshtml");
        }
        public ActionResult EventoListarVista()
        {
            return View("~/Views/Evento/EventoListarVista.cshtml");
        }
        public ActionResult EventoRegistrarVista()
        {
            return View("~/Views/Evento/EventoRegistrarVista.cshtml");
        }
        [HttpPost]
        public ActionResult EventoUsuarioListarJson()
        {
            var errormensaje = "";
            UsuarioModel usuario = (UsuarioModel)Session["UsuarioFull"];
            var lista = new List<EventoModel>();
            try
            {
                lista = eventomb.EventoUsuarioListar(usuario.Id);
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(new { data = lista.ToList(), mensaje = errormensaje });
        }
    }
}