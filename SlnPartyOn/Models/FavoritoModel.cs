using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlnPartyOn.Models
{
    public class FavoritoModel
    {
        public int id { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public bool favorito { get; set; }
    }
}