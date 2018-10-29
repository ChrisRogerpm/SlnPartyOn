using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlnPartyOn.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public int TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Imagen { get; set; }

    }
}