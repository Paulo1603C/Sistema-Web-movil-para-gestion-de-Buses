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
    public static class LugarDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static LugarEntidad Crear(LugarEntidad lugarEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarLugar
                                                             @Nombre
                                                            ,@Latitud
                                                            ,@Longitud
                                                            ,@Canton
                                                            ,@Provincia";
                cmd.Parameters.AddWithValue("Nombre", lugarEntidad.Nombre);
                cmd.Parameters.AddWithValue("Latitud", lugarEntidad.Latitud);
                cmd.Parameters.AddWithValue("Longitud", lugarEntidad.Longitud);
                cmd.Parameters.AddWithValue("Canton", lugarEntidad.Canton);
                cmd.Parameters.AddWithValue("Provincia", lugarEntidad.Provincia);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                lugarEntidad.Id = id;
                connection.Close();
                return lugarEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<LugarEntidad> ListarLugares()
        {
            List<LugarEntidad> lugarEntidads = new List<LugarEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarLugares";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    LugarEntidad lugarEntidad = new LugarEntidad();
                    lugarEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    lugarEntidad.Nombre = dr["Nombre"].ToString();
                    lugarEntidad.Latitud = Convert.ToDecimal(dr["Latitud"].ToString());
                    lugarEntidad.Longitud = Convert.ToDecimal(dr["Longitud"].ToString());
                    lugarEntidad.Canton = dr["Canton"].ToString();
                    lugarEntidad.Provincia = dr["Provincia"].ToString();

                    lugarEntidads.Add(lugarEntidad);
                }
            }
            connection.Close();
            return lugarEntidads;

        }

        public static LugarEntidad ObtenerLugarPorId(int Id)
        {
            LugarEntidad lugarEntidad = new LugarEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerLugarPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    lugarEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    lugarEntidad.Nombre = dr["Nombre"].ToString();
                    lugarEntidad.Latitud = Convert.ToDecimal(dr["Latitud"].ToString());
                    lugarEntidad.Longitud = Convert.ToDecimal(dr["Longitud"].ToString());
                    lugarEntidad.Canton = dr["Canton"].ToString();
                    lugarEntidad.Provincia = dr["Provincia"].ToString();
                }


            }
            connection.Close();
            return lugarEntidad;

        }

        public static LugarEntidad Actualizar(LugarEntidad lugarEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarLugar 
                                        @Id,
                                        @Nombre,
                                        @Latitud,
                                        @Longitud,
                                        @Canton,
                                        @Provincia";
                cmd.Parameters.AddWithValue("Id", lugarEntidad.Id);
                cmd.Parameters.AddWithValue("Nombre", lugarEntidad.Nombre);
                cmd.Parameters.AddWithValue("Latitud", lugarEntidad.Latitud);
                cmd.Parameters.AddWithValue("Longitud", lugarEntidad.Longitud);
                cmd.Parameters.AddWithValue("Canton", lugarEntidad.Canton);
                cmd.Parameters.AddWithValue("Provincia", lugarEntidad.Provincia);
                cmd.ExecuteNonQuery();
                connection.Close();
                return lugarEntidad;

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
                LugarEntidad lugarEntidad = new LugarEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarLugar @Id";
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
