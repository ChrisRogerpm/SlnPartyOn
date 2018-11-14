using SlnPartyOn.Models;
using SlnPartyOn.ModelsBusiness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlnPartyOn.Controllers
{
    public class EventoController : Controller
    {
        private EventoMB eventomb = new EventoMB();
        private FavoritoMB favoritomb = new FavoritoMB();
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
        public ActionResult EventoUsuarioEditarVistar(int Id)
        {
            ViewBag.Id = Id;
            return View("~/Views/Evento/EventoUsuarioEditarVista.cshtml");
        }
        [HttpPost]
        public ActionResult EventoUsuarioRegistrarJson(EventoModel evento)
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            try
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (Request.Files.Count > 0)
                {
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var archivoNombre = "_" + file.FileName.Replace(" ", string.Empty);
                        var path = Server.MapPath("~/Content/Evento/") + "_" + file.FileName.Replace(" ", string.Empty);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        var exists = System.IO.Directory.Exists(Server.MapPath("~/Content/Evento/"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Content/Evento/"));
                        }
                        file.SaveAs(path);
                        evento.Imagen = archivoNombre;
                        evento.UsuarioId = Convert.ToInt32(Session["Id"]);
                        respuestaConsulta = eventomb.EventoUsuarioInsertar(evento);
                    }
                }
                else
                {
                    respuestaConsulta = false;
                    errormensaje = "No se pudo registrar el Evento";
                }

            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + " ,Llame Administrador";
            }

            return Json(new { respuesta = respuestaConsulta, mensaje = errormensaje });
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
        [HttpPost]
        public ActionResult EventoUsuarioIDObtenerJson(int Id)
        {
            var errormensaje = "";
            var evento = new EventoModel();
            bool respuestaconsulta = false;
            try
            {
                evento = eventomb.EventoIDJson(Id);
                respuestaconsulta = true;

            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }

            return Json(new { data = evento,respuesta = respuestaconsulta, mensaje = errormensaje });
        }
        [HttpPost]
        public ActionResult EventoUsuarioEditarJson(EventoModel evento)
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            try
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (Request.Files.Count > 0)
                {
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var archivoNombre = "_" + file.FileName.Replace(" ", string.Empty);
                        var path = Server.MapPath("~/Content/Evento/") + "_" + file.FileName.Replace(" ", string.Empty);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        var exists = System.IO.Directory.Exists(Server.MapPath("~/Content/Evento/"));
                        if (!exists)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Content/Evento/"));
                        }
                        file.SaveAs(path);
                        evento.Imagen = archivoNombre;
                        evento.UsuarioId = Convert.ToInt32(Session["Id"]);
                        respuestaConsulta = eventomb.EventoUsuarioEditar(evento);
                    }
                    else
                    {
                        evento.UsuarioId = Convert.ToInt32(Session["Id"]);
                        respuestaConsulta = eventomb.EventoUsuarioEditar(evento);
                    }
                }
                else
                {
                    
                }

            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + " ,Llame Administrador";
            }

            return Json(new { respuesta = respuestaConsulta, mensaje = errormensaje });
        }

        [HttpPost]
        public ActionResult TotalFavoritosEventoJson(int Id)
        {
            var errormensaje = "";
            int respuestaconsulta = 0;
            try
            {
                respuestaconsulta = favoritomb.TotalFavoritosEvento(Id);
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }

            return Json(new { data = respuestaconsulta, mensaje = errormensaje });
        }
    }
}