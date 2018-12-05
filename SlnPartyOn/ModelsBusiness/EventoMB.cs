using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SlnPartyOn.Funciones;
using SlnPartyOn.Models;

namespace SlnPartyOn.ModelsBusiness
{
    public class EventoMB
    {
        string _conexion = string.Empty;
        public EventoMB()
        {
            _conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }

        public List<EventoModel> EventoUsuarioListar(int id)
        {
            List<EventoModel> lista = new List<EventoModel>();
            string consulta = @"SELECT [id]
                                ,[Nombre_Evento]
                                ,[Descripcion_Evento]
                                ,[UsuarioId]
                                ,[CategoriaId]
                                ,[FechaInicioEvento]
                                ,[HoraEvento]
                                ,[Direccion_Evento]
                                ,[Imagen]
                                ,[Estado_Evento]
                                ,[latitud]
                                ,[longitud]
                            FROM [dbo].[Evento]
                            where UsuarioId = @p0
                            order by Id Desc";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", id);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var eventomodel = new EventoModel
                            {
                                Id = Utilitarios.ValidarInteger(dr["Id"]),
                                Nombre_Evento = Utilitarios.ValidarStr(dr["Nombre_Evento"]),
                                Descripcion_Evento = Utilitarios.ValidarStr(dr["Descripcion_Evento"]),
                                UsuarioId = Utilitarios.ValidarInteger(dr["UsuarioId"]),
                                CategoriaId = Utilitarios.ValidarInteger(dr["CategoriaId"]),
                                FechaInicioEvento = Utilitarios.ValidarDate(dr["FechaInicioEvento"]),
                                HoraEvento = Utilitarios.ValidarStr(dr["HoraEvento"]),
                                Direccion_Evento = Utilitarios.ValidarStr(dr["Direccion_Evento"]),
                                Imagen = Utilitarios.ValidarStr(dr["Imagen"]),
                                Estado_Evento = Utilitarios.ValidarBool(dr["Estado_Evento"]),
                                latitud = Utilitarios.ValidarStr(dr["latitud"]),
                                longitud = Utilitarios.ValidarStr(dr["longitud"])
                            };
                            lista.Add(eventomodel);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }
        public List<EventoModel> EventoCategoriaListar(int id)
        {
            List<EventoModel> lista = new List<EventoModel>();
            string consulta = @"SELECT [id]
                                ,[Nombre_Evento]
                                ,[Descripcion_Evento]
                                ,[UsuarioId]
                                ,[CategoriaId]
                                ,[FechaInicioEvento]
                                ,[HoraEvento]
                                ,[Direccion_Evento]
                                ,[Imagen]
                                ,[Estado_Evento]
                                ,[latitud]
                                ,[longitud]
                            FROM [dbo].[Evento]
                            where CategoriaId = @p0
                            order by Id Desc";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", id);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var eventomodel = new EventoModel
                            {
                                Id = Utilitarios.ValidarInteger(dr["Id"]),
                                Nombre_Evento = Utilitarios.ValidarStr(dr["Nombre_Evento"]),
                                Descripcion_Evento = Utilitarios.ValidarStr(dr["Descripcion_Evento"]),
                                UsuarioId = Utilitarios.ValidarInteger(dr["UsuarioId"]),
                                CategoriaId = Utilitarios.ValidarInteger(dr["CategoriaId"]),
                                FechaInicioEvento = Utilitarios.ValidarDate(dr["FechaInicioEvento"]),
                                HoraEvento = Utilitarios.ValidarStr(dr["HoraEvento"]),
                                Direccion_Evento = Utilitarios.ValidarStr(dr["Direccion_Evento"]),
                                Imagen = Utilitarios.ValidarStr(dr["Imagen"]),
                                Estado_Evento = Utilitarios.ValidarBool(dr["Estado_Evento"]),
                                latitud = Utilitarios.ValidarStr(dr["latitud"]),
                                longitud = Utilitarios.ValidarStr(dr["longitud"])
                            };
                            lista.Add(eventomodel);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }
        public List<EventoModel> EventoListar()
        {
            List<EventoModel> lista = new List<EventoModel>();
            string consulta = @"select (select count(ad.Id) from Asistente ad where ad.EventoId = e.Id) as Asistencia, e.* 
                                from Evento e where e.estado_evento = 1";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var eventomodel = new EventoModel
                            {
                                Asistentes = Utilitarios.ValidarStr(dr["Asistencia"]),
                                Id = Utilitarios.ValidarInteger(dr["Id"]),
                                Nombre_Evento = Utilitarios.ValidarStr(dr["Nombre_Evento"]),
                                Descripcion_Evento = Utilitarios.ValidarStr(dr["Descripcion_Evento"]),
                                UsuarioId = Utilitarios.ValidarInteger(dr["UsuarioId"]),
                                CategoriaId = Utilitarios.ValidarInteger(dr["CategoriaId"]),
                                FechaInicioEvento = Utilitarios.ValidarDate(dr["FechaInicioEvento"]),
                                HoraEvento = Utilitarios.ValidarStr(dr["HoraEvento"]),
                                Direccion_Evento = Utilitarios.ValidarStr(dr["Direccion_Evento"]),
                                Imagen = Utilitarios.ValidarStr(dr["Imagen"]),
                                Estado_Evento = Utilitarios.ValidarBool(dr["Estado_Evento"]),
                                latitud = Utilitarios.ValidarStr(dr["latitud"]),
                                longitud = Utilitarios.ValidarStr(dr["longitud"])
                            };
                            lista.Add(eventomodel);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }
        //CANTIDAD DE EVENTOS POR MES
        public List<EventoModel> EventosporMes()
        {
            List<EventoModel> lista = new List<EventoModel>();
            string consulta = @"SELECT COUNT (*) AS Total, 
                                MONTH(FechaInicioEvento) AS Mes,
								CAT.Descripcion AS Descripcion
                                FROM Evento EVE
								inner join  Categoria CAT
								ON EVE.CategoriaId = CAT.Id
                                WHERE YEAR(FechaInicioEvento)= 2018
                                GROUP BY MONTH(FechaInicioEvento), CAT.Descripcion 
								ORDER BY CAT.Descripcion, MONTH(FechaInicioEvento) ASC
                                ;";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var eventomodel = new EventoModel
                            {
                                
                                Total = Utilitarios.ValidarInteger(dr["Total"]),
                                Mes = Utilitarios.ValidarInteger(dr["Mes"]),
                                Descripcion_Categoria = Utilitarios.ValidarStr(dr["Descripcion"])
                            };
                            lista.Add(eventomodel);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return _FormatearLista(lista);
        }

        private List<EventoModel> _FormatearLista(List<EventoModel> ListaEvento)
        {
            List<EventoModel> EventoModel = new List<EventoModel>();
            List<EventoModel> Modelo = new List<EventoModel>();


            string CategoriaBa = "";

            foreach (var Evento in ListaEvento)
            {
                if (!CategoriaBa.Equals(Evento.Descripcion_Categoria))
                {
                    CategoriaBa = Evento.Descripcion_Categoria;
                    for (int i = 1; i <= 12; i++)
                    {
                        EventoModel Model = new EventoModel();
                        Model.Mes = i;
                        Model.Total = 0;
                        Model.Descripcion_Categoria = Evento.Descripcion_Categoria;
                        Modelo.Add(Model);
                    }
                }
            }

            Modelo = Modelo.OrderBy(g => g.Mes).OrderBy(g => g.Descripcion_Categoria).ToList();

            foreach (var Mode in Modelo)
            {
                foreach (var Lista in ListaEvento)
                {
                    if (Mode.Descripcion_Categoria.Equals(Lista.Descripcion_Categoria))
                    {
                        if (Mode.Mes == Lista.Mes)
                        {
                            Mode.Total = Lista.Total;
                        }
                    }
                }
            }

            string CategoriaBase = "";

            foreach (var Lista in ListaEvento)
            {
                if (!CategoriaBase.Equals(Lista.Descripcion_Categoria))
                {
                    CategoriaBase = Lista.Descripcion_Categoria;
                    EventoModel Mod = new EventoModel();
                    Mod.Descripcion_Categoria = CategoriaBase;
                    EventoModel.Add(Mod);
                }
            }

            foreach (var Lista in EventoModel)
            {
                List<int> ListaB = new List<int>();
                foreach (var Lista2 in Modelo)
                {
                    if (Lista.Descripcion_Categoria.Equals(Lista2.Descripcion_Categoria))
                    {
                        ListaB.Add(Lista2.Total);
                    }
                }
                Lista.Cantidad_Evento = ListaB;
            }

            return EventoModel;
        }
        // END CANTIDAD DE EVENTOS POR MES




        public bool EventoUsuarioInsertar(EventoModel evento)
        {
            bool respuesta = false;
            string consulta = @"INSERT INTO [dbo].[Evento]
           ([Nombre_Evento]
           ,[Descripcion_Evento]
           ,[UsuarioId]
           ,[CategoriaId]
           ,[FechaInicioEvento]
           ,[HoraEvento]
           ,[Direccion_Evento]
           ,[Imagen]
           ,[Estado_Evento]
           ,[latitud]
           ,[longitud])
     VALUES
           (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarStr(evento.Nombre_Evento));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(evento.Descripcion_Evento));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarInteger(evento.UsuarioId));
                    query.Parameters.AddWithValue("@p3", Utilitarios.ValidarInteger(evento.CategoriaId));
                    query.Parameters.AddWithValue("@p4", Utilitarios.ValidarDate(evento.FechaInicioEvento));
                    query.Parameters.AddWithValue("@p5", Utilitarios.ValidarStr(evento.HoraEvento));
                    query.Parameters.AddWithValue("@p6", Utilitarios.ValidarStr(evento.Direccion_Evento));
                    query.Parameters.AddWithValue("@p7", Utilitarios.ValidarStr(evento.Imagen));
                    query.Parameters.AddWithValue("@p8", Utilitarios.ValidarBool(1));
                    query.Parameters.AddWithValue("@p9", Utilitarios.ValidarStr(evento.latitud));
                    query.Parameters.AddWithValue("@p10", Utilitarios.ValidarStr(evento.longitud));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }

            return respuesta;
        }
        public bool EventoUsuarioEditar(EventoModel evento)
        {
            bool respuesta = false;
            string consulta = @"UPDATE [dbo].[Evento]
                               SET [Nombre_Evento] = @p0
                                  ,[Descripcion_Evento] = @p1
                                  ,[UsuarioId] = @p2
                                  ,[CategoriaId] = @p3
                                  ,[FechaInicioEvento] = @p4
                                  ,[HoraEvento] = @p5
                                  ,[Direccion_Evento] = @p6
                                   {0}
                                  ,[Estado_Evento] = @p8
                                  ,[latitud] = @p9
                                  ,[longitud] = @p10
                             WHERE id = @p11";

            string Imagen = evento.Imagen == null ? "" : ",[Imagen] = @p7";

            consulta = String.Format(consulta, Imagen);

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarStr(evento.Nombre_Evento));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(evento.Descripcion_Evento));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarInteger(evento.UsuarioId));
                    query.Parameters.AddWithValue("@p3", Utilitarios.ValidarInteger(evento.CategoriaId));
                    query.Parameters.AddWithValue("@p4", Utilitarios.ValidarDate(evento.FechaInicioEvento));
                    query.Parameters.AddWithValue("@p5", Utilitarios.ValidarStr(evento.HoraEvento));
                    query.Parameters.AddWithValue("@p6", Utilitarios.ValidarStr(evento.Direccion_Evento));
                    query.Parameters.AddWithValue("@p7", Utilitarios.ValidarStr(evento.Imagen));
                    query.Parameters.AddWithValue("@p8", Utilitarios.ValidarBool(evento.Estado_Evento));
                    query.Parameters.AddWithValue("@p9", Utilitarios.ValidarStr(evento.latitud));
                    query.Parameters.AddWithValue("@p10", Utilitarios.ValidarStr(evento.longitud));
                    query.Parameters.AddWithValue("@p11", Utilitarios.ValidarInteger(evento.Id));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }

            return respuesta;
        }
        public EventoModel EventoIDJson(int Id)
        {
            EventoModel eventoModel = new EventoModel();
            string consulta = @"SELECT [id]
                                  ,[Nombre_Evento]
                                  ,[Descripcion_Evento]
                                  ,[UsuarioId]
                                  ,[CategoriaId]
                                  ,[FechaInicioEvento]
                                  ,[HoraEvento]
                                  ,[Direccion_Evento]
                                  ,[Imagen]
                                  ,[Estado_Evento]
                                  ,[latitud]
                                  ,[longitud]
                              FROM [dbo].[Evento] 
                                where id = @p0";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Id);

                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                eventoModel.Id = Utilitarios.ValidarInteger(dr["id"]);
                                eventoModel.Nombre_Evento = Utilitarios.ValidarStr(dr["Nombre_Evento"]);
                                eventoModel.Descripcion_Evento = Utilitarios.ValidarStr(dr["Descripcion_Evento"]);
                                eventoModel.UsuarioId = Utilitarios.ValidarInteger(dr["UsuarioId"]);
                                eventoModel.CategoriaId = Utilitarios.ValidarInteger(dr["CategoriaId"]);
                                eventoModel.FechaInicioEvento = Utilitarios.ValidarDate(dr["FechaInicioEvento"]);
                                eventoModel.HoraEvento = Utilitarios.ValidarStr(dr["HoraEvento"]);
                                eventoModel.Direccion_Evento = Utilitarios.ValidarStr(dr["Direccion_Evento"]);
                                eventoModel.Imagen = Utilitarios.ValidarStr(dr["Imagen"]);
                                eventoModel.Estado_Evento = Utilitarios.ValidarBool(dr["Estado_Evento"]);
                                eventoModel.latitud = Utilitarios.ValidarStr(dr["latitud"]);
                                eventoModel.longitud = Utilitarios.ValidarStr(dr["longitud"]);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
            }
            return eventoModel;
        }
    }
}