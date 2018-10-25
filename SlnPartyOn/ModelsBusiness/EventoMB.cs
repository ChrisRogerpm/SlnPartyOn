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
    }
}