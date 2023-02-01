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
    public static class RutaDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static RutaEntidad Crear(RutaEntidad rutaEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarRuta
                                             @Descripcion,
                                            @IdLugarOrigen,
                                            @IdLugarDestino";
                cmd.Parameters.AddWithValue("Descripcion", rutaEntidad.Descripcion);
                cmd.Parameters.AddWithValue("IdLugarOrigen", rutaEntidad.IdLugarOrigen);
                cmd.Parameters.AddWithValue("IdLugarDestino", rutaEntidad.IdLugarDestino);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                rutaEntidad.Id = id;
                connection.Close();
                return rutaEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<RutaEntidad> ListarRutas()
        {
            List<RutaEntidad> rutaEntidads = new List<RutaEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarRutas";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    RutaEntidad rutaEntidad = new RutaEntidad();
                    rutaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    rutaEntidad.Descripcion = dr["Descripcion"].ToString();
                    rutaEntidad.IdLugarOrigen = Convert.ToInt32(dr["IdLugarOrigen"].ToString());
                    rutaEntidad.LugarOrigen = dr["LugarOrigen"].ToString();
                    rutaEntidad.IdLugarDestino = Convert.ToInt32(dr["IdLugarDestino"].ToString());
                    rutaEntidad.LugarDestino = dr["LugarDestino"].ToString();

                    rutaEntidads.Add(rutaEntidad);
                }
            }
            connection.Close();
            return rutaEntidads;

        }

        public static RutaEntidad ObtenerRutaPorId(int Id)
        {
            RutaEntidad rutaEntidad = new RutaEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerRutaPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    rutaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    rutaEntidad.Descripcion = dr["Descripcion"].ToString();
                    rutaEntidad.IdLugarOrigen = Convert.ToInt32(dr["IdLugarOrigen"].ToString());
                    rutaEntidad.LugarOrigen = dr["LugarOrigen"].ToString();
                    rutaEntidad.IdLugarDestino = Convert.ToInt32(dr["IdLugarDestino"].ToString());
                    rutaEntidad.LugarDestino = dr["LugarDestino"].ToString();
                }


            }
            connection.Close();
            return rutaEntidad;

        }

        public static RutaEntidad Actualizar(RutaEntidad rutaEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarRuta 
                                        @Id,
                                        @Descripcion,
                                        @IdLugarOrigen,
                                        @IdLugarDestino";
                cmd.Parameters.AddWithValue("Id", rutaEntidad.Id);
                cmd.Parameters.AddWithValue("Descripcion", rutaEntidad.Descripcion);
                cmd.Parameters.AddWithValue("IdLugarOrigen", rutaEntidad.IdLugarOrigen);
                cmd.Parameters.AddWithValue("IdLugarDestino", rutaEntidad.IdLugarDestino);
                cmd.ExecuteNonQuery();
                connection.Close();
                return rutaEntidad;

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
                RutaEntidad rutaEntidad = new RutaEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarRuta @Id";
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
