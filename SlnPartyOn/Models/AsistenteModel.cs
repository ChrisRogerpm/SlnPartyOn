using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlnPartyOn.Models
{
    public class AsistenteModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public bool Asistente { get; set; }
    }
}