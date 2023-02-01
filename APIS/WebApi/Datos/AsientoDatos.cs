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
    public static class AsientoDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static AsientoEntidad Crear(AsientoEntidad asientoEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarAsiento
                                             @IdBus
                                            ,@Orden
                                            ,@Descripcion
                                            ,@IdCategoria";
                cmd.Parameters.AddWithValue("IdBus", asientoEntidad.IdBus);
                cmd.Parameters.AddWithValue("Orden", asientoEntidad.Orden);
                cmd.Parameters.AddWithValue("Descripcion", asientoEntidad.Descripcion);
                cmd.Parameters.AddWithValue("IdCategoria", asientoEntidad.IdCategoria);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                asientoEntidad.Id = id;
                connection.Close();
                return asientoEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static AsientoEntidad Actualizar(AsientoEntidad asientoEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarAsiento 
                                        @Id
                                        ,@IdBus
                                        ,@Orden
                                        ,@Descripcion
                                        ,@IdCategoria";
                cmd.Parameters.AddWithValue("Id", asientoEntidad.Id);
                cmd.Parameters.AddWithValue("IdBus", asientoEntidad.IdBus);
                cmd.Parameters.AddWithValue("Orden", asientoEntidad.Orden);
                cmd.Parameters.AddWithValue("Descripcion", asientoEntidad.Descripcion);
                cmd.Parameters.AddWithValue("IdCategoria", asientoEntidad.IdCategoria);
                cmd.ExecuteNonQuery();
                connection.Close();
                return asientoEntidad;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public static List<AsientoEntidad> ListarAsientos()
        {
            List<AsientoEntidad> asientoEntidads = new List<AsientoEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarAsientos";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    AsientoEntidad asientoEntidad = new AsientoEntidad();
                    asientoEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    asientoEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                    asientoEntidad.Bus = dr["Bus"].ToString();
                    asientoEntidad.Orden = Convert.ToInt32(dr["Orden"].ToString());
                    asientoEntidad.Descripcion = dr["Descripcion"].ToString();
                    asientoEntidad.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    asientoEntidad.Categoria = dr["Categoria"].ToString();

                    asientoEntidads.Add(asientoEntidad);
                }
            }
            connection.Close();
            return asientoEntidads;

        }
        public static List<AsientoEntidad> ListarAsientosPorIdBus(int IdBus)
        {
            List<AsientoEntidad> asientoEntidads = new List<AsientoEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarAsientosPorIdBus @IdBus";
            cmd.Parameters.AddWithValue("IdBus", IdBus);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    AsientoEntidad asientoEntidad = new AsientoEntidad();
                    asientoEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    asientoEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                    asientoEntidad.Bus = dr["Bus"].ToString();
                    asientoEntidad.Orden = Convert.ToInt32(dr["Orden"].ToString());
                    asientoEntidad.Descripcion = dr["Descripcion"].ToString();
                    asientoEntidad.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    asientoEntidad.Categoria = dr["Categoria"].ToString();

                    asientoEntidads.Add(asientoEntidad);
                }
            }
            connection.Close();
            return asientoEntidads;

        }

        public static AsientoEntidad ObtenerAsientoPorId(int Id)
        {
            AsientoEntidad asientoEntidad = new AsientoEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerAsientoPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    asientoEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    asientoEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                    asientoEntidad.Bus = dr["Bus"].ToString();
                    asientoEntidad.Orden = Convert.ToInt32(dr["Orden"].ToString());
                    asientoEntidad.Descripcion = dr["Descripcion"].ToString();
                    asientoEntidad.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    asientoEntidad.Categoria = dr["Categoria"].ToString();
                }


            }
            connection.Close();
            return asientoEntidad;

        }

        public static bool Eliminar(int Id)
        {
            try
            {
                AsientoEntidad asientoEntidad = new AsientoEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarAsiento @Id";
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
