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