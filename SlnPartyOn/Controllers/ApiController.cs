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
        private AsistenteMB asistentemb = new AsistenteMB();
        private FavoritoMB favoritomb = new FavoritoMB();
        //private Favorito

        //[HttpPost]
        public ActionResult IniciarSesionLoginWebService(string Email, string Password)
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            string resultado = string.Empty;
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
            //return Json(usuario);
            return Json(usuario, JsonRequestBehavior.AllowGet);
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
            return Json(lista, JsonRequestBehavior.AllowGet);

        }
        
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
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        
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
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        
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
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        
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
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        
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
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult MarcarAsistente(int UsuarioId,int EventoId)
        {
            var errormensaje = "";
            int asistente = 0;
            try
            {
                asistente = asistentemb.CantidadAsistente(UsuarioId, EventoId);
                if(asistente > 0)
                {
                    asistentemb.BorrarAsistente(UsuarioId, EventoId);
                }
                else
                {
                    asistentemb.AsistenteInsertar(UsuarioId, EventoId);
                }
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(asistente, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MarcarFavoritos(int UsuarioId, int EventoId)
        {
            var errormensaje = "";
            int favoritos = 0;
            try
            {
                favoritos = favoritomb.CantidadFavoritos(UsuarioId, EventoId);
                if (favoritos > 0)
                {
                    favoritomb.BorrarFavoritos(UsuarioId, EventoId);
                }
                else
                {
                    favoritomb.FavoritosInsertar(UsuarioId, EventoId);
                }
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + ",Llame Administrador";
            }
            return Json(favoritos, JsonRequestBehavior.AllowGet);
        }


    }
}