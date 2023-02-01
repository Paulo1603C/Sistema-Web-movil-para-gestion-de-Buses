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
    public static class FrecuenciaParadaDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static FrecuenciaParadaEntidad Crear(FrecuenciaParadaEntidad frecuenciaParadaEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarFrecuenciaParada
                                             @IdFrecuencia
                                            ,@IdLugar
                                            ,@Orden";
                cmd.Parameters.AddWithValue("IdFrecuencia", frecuenciaParadaEntidad.IdFrecuencia);
                cmd.Parameters.AddWithValue("IdLugar", frecuenciaParadaEntidad.IdLugar);
                cmd.Parameters.AddWithValue("Orden", frecuenciaParadaEntidad.Orden);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                frecuenciaParadaEntidad.Id = id;
                connection.Close();
                return frecuenciaParadaEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static FrecuenciaParadaEntidad Actualizar(FrecuenciaParadaEntidad frecuenciaParadaEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarFrecuenciaParada 
                                        @Id
                                        ,@IdFrecuencia
                                        ,@IdLugar
                                        ,@Orden";
                cmd.Parameters.AddWithValue("Id", frecuenciaParadaEntidad.Id);
                cmd.Parameters.AddWithValue("IdFrecuencia", frecuenciaParadaEntidad.IdFrecuencia);
                cmd.Parameters.AddWithValue("IdLugar", frecuenciaParadaEntidad.IdLugar);
                cmd.Parameters.AddWithValue("Orden", frecuenciaParadaEntidad.Orden);
                cmd.ExecuteNonQuery();
                connection.Close();
                return frecuenciaParadaEntidad;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public static List<FrecuenciaParadaEntidad> ListarFrecuenciasParada()
        {
            List<FrecuenciaParadaEntidad> frecuenciaParadaEntidads = new List<FrecuenciaParadaEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarFrecuenciasParada";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    FrecuenciaParadaEntidad frecuenciaParadaEntidad = new FrecuenciaParadaEntidad();
                    frecuenciaParadaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    frecuenciaParadaEntidad.IdFrecuencia = Convert.ToInt32(dr["IdFrecuencia"].ToString());
                    frecuenciaParadaEntidad.Frecuencia = dr["Frecuencia"].ToString();
                    frecuenciaParadaEntidad.IdLugar = Convert.ToInt32(dr["IdLugar"].ToString());
                    frecuenciaParadaEntidad.Lugar = dr["Lugar"].ToString();
                    frecuenciaParadaEntidad.Orden = Convert.ToInt32(dr["Orden"].ToString());

                    frecuenciaParadaEntidads.Add(frecuenciaParadaEntidad);
                }
            }
            connection.Close();
            return frecuenciaParadaEntidads;

        }

        public static FrecuenciaParadaEntidad ObtenerFrecuenciaParadaPorId(int Id)
        {
            FrecuenciaParadaEntidad frecuenciaParadaEntidad = new FrecuenciaParadaEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerFrecuenciaParadaPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    frecuenciaParadaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    frecuenciaParadaEntidad.IdFrecuencia = Convert.ToInt32(dr["IdFrecuencia"].ToString());
                    frecuenciaParadaEntidad.Frecuencia = dr["Frecuencia"].ToString();
                    frecuenciaParadaEntidad.IdLugar = Convert.ToInt32(dr["IdLugar"].ToString());
                    frecuenciaParadaEntidad.Lugar = dr["Lugar"].ToString();
                    frecuenciaParadaEntidad.Orden = Convert.ToInt32(dr["Orden"].ToString());
                }


            }
            connection.Close();
            return frecuenciaParadaEntidad;

        }

        public static bool Eliminar(int Id)
        {
            try
            {
                FrecuenciaParadaEntidad frecuenciaParadaEntidad = new FrecuenciaParadaEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarFrecuenciaParada @Id";
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
