using Entidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class CategoriaDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static CategoriaEntidad Crear(CategoriaEntidad categoriaEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarCategoria
                                             @Descripcion
                                             ,@IdCooperativa";
                cmd.Parameters.AddWithValue("Descripcion", categoriaEntidad.Descripcion);
                cmd.Parameters.AddWithValue("IdCooperativa", categoriaEntidad.IdCooperativa);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                categoriaEntidad.Id = id;
                connection.Close();
                return categoriaEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<CategoriaEntidad> ListarCategorias()
        {
            List<CategoriaEntidad> categoriaEntidads = new List<CategoriaEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarCategorias";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    CategoriaEntidad categoriaEntidad = new CategoriaEntidad();
                    categoriaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    categoriaEntidad.Descripcion = dr["Descripcion"].ToString();
                    categoriaEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    categoriaEntidad.Cooperativa = dr["Cooperativa"].ToString();

                    categoriaEntidads.Add(categoriaEntidad);
                }
            }
            connection.Close();
            return categoriaEntidads;

        }

        public static CategoriaEntidad ObtenerCategoriaPorId(int Id)
        {
            CategoriaEntidad categoriaEntidad = new CategoriaEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerCategoriaPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    categoriaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    categoriaEntidad.Descripcion = dr["Descripcion"].ToString();
                    categoriaEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    categoriaEntidad.Cooperativa = dr["Cooperativa"].ToString();
                }


            }
            connection.Close();
            return categoriaEntidad;

        }

        public static CategoriaEntidad Actualizar(CategoriaEntidad categoriaEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarCategoria 
                                        @Id,
                                        @Descripcion,
                                        @IdCooperativa";
                cmd.Parameters.AddWithValue("Id", categoriaEntidad.Id);
                cmd.Parameters.AddWithValue("Descripcion", categoriaEntidad.Descripcion);
                cmd.Parameters.AddWithValue("IdCooperativa", categoriaEntidad.IdCooperativa);
                cmd.ExecuteNonQuery();
                connection.Close();
                return categoriaEntidad;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public static bool Eliminar(int Id)
        {
            try
            {
                CategoriaEntidad categoriaEntidad = new CategoriaEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarCategoria @Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
