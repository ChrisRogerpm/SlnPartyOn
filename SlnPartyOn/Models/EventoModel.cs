using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlnPartyOn.Models
{
    public class EventoModel
    {
        public int Id { get; set; }
        public string Nombre_Evento { get; set; }
        public string Descripcion_Evento { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public DateTime FechaInicioEvento { get; set; }
        public string HoraEvento { get; set; }
        public string Direccion_Evento { get; set; }
        public string Imagen { get; set; }
        public bool Estado_Evento { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string Asistentes { get; set; }

        public int Total { get; set; }
        public int Mes { get; set; }
        public string Descripcion_Categoria { get; set; }

        public List<int> Cantidad_Evento { get; set; }  
    }
}