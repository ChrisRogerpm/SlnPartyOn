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

        public List<UsuarioModel> UsuarioListar()
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

        public bool UsuarioInsertar(UsuarioModel usuario)
        {
            bool respuesta = false;
            string consulta = @"INSERT INTO [dbo].[Usuario]
                               ([TipoUsuario]
                               ,[Nombre]
                               ,[Apellido]
                               ,[Telefono]
                               ,[Email]
                               ,[Password]
                               ,[FechaRegistro]
                               ,[Imagen])
                                 VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

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
                    query.Parameters.AddWithValue("@p7", Utilitarios.ValidarStr(usuario.Imagen));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }

            return respuesta;
        }

        public int UsuarioInsertarLogin(UsuarioModel usuario)
        {
            int UsuarioId = 0;
            string consulta = @"INSERT INTO [dbo].[Usuario]
                               ([TipoUsuario]
                               ,[Nombre]
                               ,[Apellido]
                               ,[Telefono]
                               ,[Email]
                               ,[Password]
                               ,[FechaRegistro]
                               ,[Imagen])
                                 VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7);SELECT SCOPE_IDENTITY()";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarInteger(2));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(usuario.Nombre));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarStr(usuario.Apellido));
                    query.Parameters.AddWithValue("@p3", Utilitarios.ValidarStr(usuario.Telefono));
                    query.Parameters.AddWithValue("@p4", Utilitarios.ValidarStr(usuario.Email));
                    query.Parameters.AddWithValue("@p5", Utilitarios.ValidarStr(usuario.Password));
                    query.Parameters.AddWithValue("@p6", Utilitarios.ValidarDate(DateTime.Now));
                    query.Parameters.AddWithValue("@p7", Utilitarios.ValidarStr("Default.png"));
                    UsuarioId = Int32.Parse(query.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
            }

            return UsuarioId;
        }

        public bool UsuarioEditar(UsuarioModel usuario)
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
                                    {0}
                             WHERE Id = @p9";

            string ImagenEntrante = usuario.Imagen == null ? "" : ",[Imagen] = @p8";
            consulta = String.Format(consulta, ImagenEntrante);

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
                    query.Parameters.AddWithValue("@p8", Utilitarios.ValidarDate(usuario.Imagen));
                    query.Parameters.AddWithValue("@p9", Utilitarios.ValidarInteger(usuario.Id));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }

            return respuesta;
        }

        public UsuarioModel UsuarioIDObtener(int usuarioId)
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
                                  ,[Imagen]
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
                                usuario.Imagen = Utilitarios.ValidarStr(dr["Imagen"]);
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

        public UsuarioModel UsuarioCoincidencia(string Email)
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