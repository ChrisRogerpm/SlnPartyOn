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
        //[HttpPost]
        //public ActionResult UsuarioRegistrarJson()
        //{

        //}
        //[HttpPost]
        //public ActionResult UsuarioEditarJson()
        //{

        //}
        [HttpPost]
        public ActionResult IniciarSesionLoginJson(string Email, string Password)
        {
            var errormensaje = "";
            bool respuestaConsulta = false;
            var usuario = new UsuarioModel();

            try
            {
                usuario = usuarioBm.UsuarioCoincidenciaJson(Email);
                if(usuario.Id > 0)
                {
                    respuestaConsulta = PasswordHashTool.PasswordHashManager.ValidatePassword(Password, usuario.Password);
                    if (respuestaConsulta)
                    {
                        Session["Id"] = usuario.Id;
                        Session["Nombre"] = usuario.Nombre;
                        Session["Apellido"] = usuario.Apellido;
                        Session["Email"] = usuario.Email;
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

            return Json(new { respuesta = respuestaConsulta, mensaje = errormensaje });
        }
    }
}