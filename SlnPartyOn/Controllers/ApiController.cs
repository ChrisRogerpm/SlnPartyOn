using SlnPartyOn.Models;
using SlnPartyOn.ModelsBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlnPartyOn.Controllers
{
    
    public class ApiController : Controller
    {
        private UsuarioMB usuarioBm = new UsuarioMB();
        private EventoMB eventomb = new EventoMB();
        [HttpPost]
        public ActionResult IniciarSesionLoginWebService(string Email, string Password)
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            string resultado = "";
            var tipo_usuario = 0;
            var usuario = new UsuarioModel();

            try
            {
                usuario = usuarioBm.UsuarioCoincidencia(Email);
                if (usuario.Id > 0)
                {
                    respuestaConsulta = PasswordHashTool.PasswordHashManager.ValidatePassword(Password, usuario.Password);
                    resultado = "success";
                    tipo_usuario = usuario.TipoUsuario;
                    if (!respuestaConsulta)
                    {
                        respuestaConsulta = false;
                        errormensaje = "Contraseña Incorrecta, vuelva a intentarlo, Contacte al Administrador";
                    }
                }
                else
                {
                    respuestaConsulta = false;
                    errormensaje = "Usuario no encontrado, Contacte al Administrador";
                }
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + " ,Contacte al Administrador";
            }

            //            return Json(new { respuesta = respuestaConsulta, mensaje = errormensaje, usuario_ = tipo_usuario });
            //return Json(new { respuesta = respuestaConsulta, mensaje = errormensaje, usuario_ = tipo_usuario });
            return Json(resultado);
            //return new JsonStringResult('success');
        }
        //[HttpGet]
        public ActionResult EventosJson()
        {
            var errormensaje = "";
            var lista = new List<EventoModel>();
            try
            {
                lista = eventomb.EventoListar();
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(lista.ToList(), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult ListarEventoFiestaJson()
        {
            var errormensaje = "";
            var lista = new List<EventoModel>();
            try
            {
                int id = 1;
                lista = eventomb.EventoCategoriaListar(id);
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(new { data = lista.ToList(), mensaje = errormensaje });
        }

        [HttpPost]
        public ActionResult ListarEventoMusicaJson()
        {
            var errormensaje = "";
            var lista = new List<EventoModel>();
            try
            {
                int id = 2;
                lista = eventomb.EventoCategoriaListar(id);
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(new { data = lista.ToList(), mensaje = errormensaje });
        }

        [HttpPost]
        public ActionResult ListarEventoGastronomiaJson()
        {
            var errormensaje = "";
            var lista = new List<EventoModel>();
            try
            {
                int id = 3;
                lista = eventomb.EventoCategoriaListar(id);
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(new { data = lista.ToList(), mensaje = errormensaje });
        }
        [HttpPost]
        public ActionResult ListarEventoDeporteJson()
        {
            var errormensaje = "";
            var lista = new List<EventoModel>();
            try
            {
                int id = 4;
                lista = eventomb.EventoCategoriaListar(id);
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(new { data = lista.ToList(), mensaje = errormensaje });
        }
        [HttpPost]
        public ActionResult ListarEventoOtroJson()
        {
            var errormensaje = "";
            var lista = new List<EventoModel>();
            try
            {
                int id = 5;
                lista = eventomb.EventoCategoriaListar(id);
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(new { data = lista.ToList(), mensaje = errormensaje });
        }


    }
}