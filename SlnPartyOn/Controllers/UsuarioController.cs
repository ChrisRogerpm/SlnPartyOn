using SlnPartyOn.Models;
using SlnPartyOn.ModelsBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlnPartyOn.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioMB usuarioBm = new UsuarioMB();
        public ActionResult LoginVista()
        {
            return View("~/Views/Seguridad/Login.cshtml");
        }
        public ActionResult LoginRegistroVista()
        {

            return View("~/Views/Seguridad/RegistrarLogin.cshtml");
        }
        public ActionResult InicioUsuarioVista()
        {
            return View("~/Views/Usuario/InicioUsuario.cshtml");
        }
        public ActionResult InicioAdministradorVista()
        {
            return View("~/Views/Usuario/InicioAdministrador.cshtml");
        }
        [HttpPost]
        public ActionResult UsuarioRegistrarLoginJson(UsuarioModel usuario)
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            var UsuarioID = 0;
            var usuriologin = new UsuarioModel();
            var id_tipousuario = 0;
            try
            {
                usuario.Password = PasswordHashTool.PasswordHashManager.CreateHash(usuario.Password);
                usuario.Nombre = usuario.Email;
                //usuario.Apellido = DBNull.Value;
                UsuarioID = usuarioBm.UsuarioInsertarLogin(usuario);
                if(UsuarioID > 0)
                {
                    usuriologin = usuarioBm.UsuarioIDObtener(UsuarioID);
                    Session["Id"] = usuriologin.Id;
                    Session["Nombre"] = usuriologin.Nombre;
                    Session["Apellido"] = usuriologin.Apellido;
                    Session["Email"] = usuriologin.Email;
                    Session["UsuarioFull"] = usuriologin;
                    id_tipousuario = usuriologin.TipoUsuario;
                    respuestaConsulta = true;
                }
                else
                {
                    respuestaConsulta = false;
                    errormensaje = "No se ha podido registrar el usuario";
                }
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + " ,Llame Administrador";
            }
            return Json(new { respuesta = respuestaConsulta, mensaje = errormensaje, usuario_ = id_tipousuario });
        }
        //[HttpPost]
        //public ActionResult UsuarioEditarJson()
        //{

        //}
        [HttpPost]
        public ActionResult CerrarSesionLoginJson()
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            try
            {
                Session["Id"] = null;
                Session["Nombre"] = null;
                Session["Apellido"] = null;
                Session["Email"] = null;
                Session["UsuarioFull"] = null;
                respuestaConsulta = true;
            }
            catch (Exception exp)
            {
                errormensaje = exp.Message + " ,Llame Administrador";
            }
            return Json(new { respuesta = respuestaConsulta, mensaje = errormensaje });
        }
        [HttpPost]
        public ActionResult IniciarSesionLoginJson(string Email, string Password)
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            var tipo_usuario = 0;
            var usuario = new UsuarioModel();

            try
            {
                usuario = usuarioBm.UsuarioCoincidencia(Email);
                if(usuario.Id > 0)
                {
                    respuestaConsulta = PasswordHashTool.PasswordHashManager.ValidatePassword(Password, usuario.Password);
                    tipo_usuario = usuario.TipoUsuario;
                    if (respuestaConsulta)
                    {
                        Session["Id"] = usuario.Id;
                        Session["Nombre"] = usuario.Nombre;
                        Session["Apellido"] = usuario.Apellido;
                        Session["Email"] = usuario.Email;
                        Session["UsuarioFull"] = usuario;
                    }
                    else
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