using SlnPartyOn.Funciones;
using SlnPartyOn.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SlnPartyOn.ModelsBusiness
{
    public class UsuarioMB
    {
        string _conexion = string.Empty;
        public UsuarioMB()
        {
            _conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }

        public List<UsuarioModel> UsuarioListarNombreEmpleadoJson()
        {
            List<UsuarioModel> lista = new List<UsuarioModel>();
            string consulta = @"SELECT [Id]
                                  ,[TipoUsuario]
                                  ,[Nombre]
                                  ,[Apellido]
                                  ,[Telefono]
                                  ,[Email]
                                  ,[Password]
                                  ,[FechaRegistro]
                              FROM [dbo].[Usuario]
                                order by Id Desc";
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
                            var usuario = new UsuarioModel
                            {
                                Id = Utilitarios.ValidarInteger(dr["Id"]),
                                TipoUsuario = Utilitarios.ValidarInteger(dr["TipoUsuario"]),
                                Nombre = Utilitarios.ValidarStr(dr["Nombre"]),
                                Apellido = Utilitarios.ValidarStr(dr["Apellido"]),
                                Telefono = Utilitarios.ValidarStr(dr["Telefono"]),
                                Email = Utilitarios.ValidarStr(dr["Email"]),
                                Password = Utilitarios.ValidarStr(dr["Password"]),
                                FechaRegistro = Utilitarios.ValidarDate(dr["FechaRegistro"])
                        };
                            lista.Add(usuario);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }

        public bool UsuarioInsertarJson(UsuarioModel usuario)
        {
            bool respuesta = false;
            string consulta = @"INSERT INTO [dbo].[Usuario]
                               ([TipoUsuario]
                               ,[Nombre]
                               ,[Apellido]
                               ,[Telefono]
                               ,[Email]
                               ,[Password]
                               ,[FechaRegistro])
                                 VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6)";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarInteger(usuario.TipoUsuario));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(usuario.Nombre));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarStr(usuario.Apellido));
                    query.Parameters.AddWithValue("@p3", Utilitarios.ValidarStr(usuario.Telefono));
                    query.Parameters.AddWithValue("@p4", Utilitarios.ValidarStr(usuario.Email));
                    query.Parameters.AddWithValue("@p5", Utilitarios.ValidarStr(usuario.Password));
                    query.Parameters.AddWithValue("@p6", Utilitarios.ValidarDate(usuario.FechaRegistro));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }

            return respuesta;
        }

        public bool UsuarioEditarJson(UsuarioModel usuario)
        {
            bool respuesta = false;
            string consulta = @"UPDATE [dbo].[Usuario]
                               SET [TipoUsuario] = @p1
                                  ,[Nombre] = @p2
                                  ,[Apellido] = @p3
                                  ,[Telefono] = @p4
                                  ,[Email] = @p5
                                   ,[Password] = @p6
                                  ,[FechaRegistro] = @p7
                             WHERE Id = @p8";

            //usuario.Password = usuario.Password == "" ? "" : ",[UsuarioPassword] = @p3";   //estado == "1" ? ",[FailedAttempts] = 0" : "";
            //consulta = String.Format(consulta, segUsuario.UsuarioPassword);

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarInteger(usuario.TipoUsuario));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarStr(usuario.Nombre));
                    query.Parameters.AddWithValue("@p3", Utilitarios.ValidarStr(usuario.Apellido));
                    query.Parameters.AddWithValue("@p4", Utilitarios.ValidarStr(usuario.Telefono));
                    query.Parameters.AddWithValue("@p5", Utilitarios.ValidarStr(usuario.Email));
                    query.Parameters.AddWithValue("@p6", Utilitarios.ValidarStr(usuario.Password));
                    query.Parameters.AddWithValue("@p7", Utilitarios.ValidarDate(usuario.FechaRegistro));
                    query.Parameters.AddWithValue("@p8", Utilitarios.ValidarInteger(usuario.Id));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }

            return respuesta;
        }

        public UsuarioModel UsuarioIDObtenerJson(int usuarioId)
        {
            UsuarioModel usuario = new UsuarioModel();
            string consulta = @"SELECT [Id]
                                  ,[TipoUsuario]
                                  ,[Nombre]
                                  ,[Apellido]
                                  ,[Telefono]
                                  ,[Email]
                                  ,[Password]
                                  ,[FechaRegistro]
                                  FROM [dbo].[Usuario]
                                    where Id= @p0";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", usuarioId);

                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                usuario.Id = Utilitarios.ValidarInteger(dr["Id"]);
                                usuario.TipoUsuario = Utilitarios.ValidarInteger(dr["TipoUsuario"]);
                                usuario.Nombre = Utilitarios.ValidarStr(dr["Nombre"]);
                                usuario.Apellido = Utilitarios.ValidarStr(dr["Apellido"]);
                                usuario.Telefono = Utilitarios.ValidarStr(dr["Telefono"]);
                                usuario.Email = Utilitarios.ValidarStr(dr["Email"]);
                                usuario.Password = Utilitarios.ValidarStr(dr["Password"]);
                                usuario.FechaRegistro = Utilitarios.ValidarDate(dr["FechaRegistro"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return usuario;
        }

        public UsuarioModel UsuarioCoincidenciaJson(string Email)
        {
            UsuarioModel usuario = new UsuarioModel();
            string consulta = @"SELECT [Id]
                                  ,[TipoUsuario]
                                  ,[Nombre]
                                  ,[Apellido]
                                  ,[Telefono]
                                  ,[Email]
                                  ,[Password]
                                  ,[FechaRegistro]
                                  FROM [dbo].[Usuario]
                                    where Email= @p0";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Email);
                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                usuario.Id = Utilitarios.ValidarInteger(dr["Id"]);
                                usuario.TipoUsuario = Utilitarios.ValidarInteger(dr["TipoUsuario"]);
                                usuario.Nombre = Utilitarios.ValidarStr(dr["Nombre"]);
                                usuario.Apellido = Utilitarios.ValidarStr(dr["Apellido"]);
                                usuario.Telefono = Utilitarios.ValidarStr(dr["Telefono"]);
                                usuario.Email = Utilitarios.ValidarStr(dr["Email"]);
                                usuario.Password = Utilitarios.ValidarStr(dr["Password"]);
                                usuario.FechaRegistro = Utilitarios.ValidarDate(dr["FechaRegistro"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return usuario;
        }

    }
}