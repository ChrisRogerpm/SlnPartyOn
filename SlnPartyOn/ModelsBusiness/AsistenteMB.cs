using SlnPartyOn.Funciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SlnPartyOn.ModelsBusiness
{
    public class AsistenteMB
    {
        string _conexion = string.Empty;
        public AsistenteMB()
        {
            _conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }
        public int CantidadAsistente(int usuarioId, int eventoId)
        {
            int total_resultado = 0;
            string consulta = @"SELECT count(Id) TotalAsistentes
                              FROM [dbo].[Asistente] 
                                where UsuarioId = @p0 and EventoId = @p1 ";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", usuarioId);
                    query.Parameters.AddWithValue("@p1", eventoId);

                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                total_resultado = Utilitarios.ValidarInteger(dr["TotalAsistentes"]);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
            }
            return total_resultado;
        }

        public int BorrarAsistente(int usuarioId, int eventoId)
        {
            int total_resultado = 0;
            string consulta = @"DELETE FROM [dbo].[Asistente] 
                                where UsuarioId = @p0 and EventoId = @p1 ";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", usuarioId);
                    query.Parameters.AddWithValue("@p1", eventoId);

                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            total_resultado = 1;
                        }
                        else
                        {
                            total_resultado = 0;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
            }
            return total_resultado;
        }

        public bool AsistenteInsertar(int usuarioId, int eventoId)
        {
            bool respuesta = false;
            string consulta = @"INSERT INTO [dbo].[Asistente]
                               ([UsuarioId]
                               ,[EventoId]
                               ,[Asistente])
                         VALUES
                               (@p0,@p1,@p2)";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarInteger(usuarioId));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarInteger(eventoId));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarBool(1));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }

            return respuesta;
        }

    }
}