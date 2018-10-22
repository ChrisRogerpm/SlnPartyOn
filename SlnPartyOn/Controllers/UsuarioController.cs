using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlnPartyOn.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult LoginVista()
        {
            return View("~/Views/Seguridad/Login.cshtml");
        }
        public ActionResult LoginRegistroVista()
        {
            return View("~/Views/Seguridad/RegistrarLogin.cshtml");
        }
    }
}