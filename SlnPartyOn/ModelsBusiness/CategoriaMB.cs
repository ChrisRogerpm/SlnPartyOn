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
    public class CategoriaMB
    {
        string _conexion = string.Empty;
        public CategoriaMB()
        {
            _conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }

        public List<CategoriaModel> CategoriaListar()
        {
            List<CategoriaModel> lista = new List<CategoriaModel>();
            string consulta = @"SELECT [Id]
                                      ,[Nombre]
                                      ,[Descripcion]
                                      ,[Estado]
                                    FROM [dbo].[Categoria]
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
                            var categoria = new CategoriaModel
                            {
                                Id = Utilitarios.ValidarInteger(dr["Id"]),
                                Nombre = Utilitarios.ValidarStr(dr["Nombre"]),
                                Descripcion = Utilitarios.ValidarStr(dr["Descripcion"]),
                                Estado = Utilitarios.ValidarBool(dr["Estado"]),
                            };
                            lista.Add(categoria);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }
        public List<CategoriaModel> EventoporCategoria()
        {
            List<CategoriaModel> lista = new List<CategoriaModel>();
            string consulta = @"select COUNT(Categoria.Id) as Total,Nombre
                                from Categoria
                                inner join Evento
                                on Categoria.Id = Evento.CategoriaId
                                group by Categoria.Nombre";
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
                            var categoria = new CategoriaModel
                            {
                                Id = Utilitarios.ValidarInteger(dr["Id"]),
                                Nombre = Utilitarios.ValidarStr(dr["Nombre"]),
                                Total = Utilitarios.ValidarInteger(dr["Total"])
                                
                            };
                            lista.Add(categoria);
                        }
                    }

                }

            }
            catch (Exception e)
            {
                
            }
            return lista;

        }
    }
}