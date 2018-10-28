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
        public ActionResult IniciarSesionLoginWebService(string Email, string Password)
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            var tipo_usuario = 0;
            var usuario = new UsuarioModel();

            try
            {
                usuario = usuarioBm.UsuarioCoincidencia(Email);
                if (usuario.Id > 0)
                {
                    respuestaConsulta = PasswordHashTool.PasswordHashManager.ValidatePassword(Password, usuario.Password);
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

            return Json(new { respuesta = respuestaConsulta, mensaje = errormensaje, usuario_ = tipo_usuario });
        }
    }
}