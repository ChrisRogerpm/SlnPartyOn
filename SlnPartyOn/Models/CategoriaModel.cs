using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlnPartyOn.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public int Total { get; set; }


    }
}