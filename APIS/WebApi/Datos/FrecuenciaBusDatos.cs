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
    public static class FrecuenciaBusDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static FrecuenciaBusEntidad Crear(FrecuenciaBusEntidad frecuenciaBusEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarFrecuenciaBus
                                             @IdFrecuencia
                                            ,@IdBus
                                            ,@Habilitado
                                            ,@IdUsuarioH";
                cmd.Parameters.AddWithValue("IdFrecuencia", frecuenciaBusEntidad.IdFrecuencia);
                cmd.Parameters.AddWithValue("IdBus", frecuenciaBusEntidad.IdBus);
                cmd.Parameters.AddWithValue("Habilitado", frecuenciaBusEntidad.Habilitado);
                cmd.Parameters.AddWithValue("IdUsuarioH", frecuenciaBusEntidad.IdUsuarioH);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                frecuenciaBusEntidad.Id = id;
                connection.Close();
                return frecuenciaBusEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static FrecuenciaBusEntidad Actualizar(FrecuenciaBusEntidad frecuenciaBusEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarFrecuenciaBus 
                                        @Id
                                        ,@IdFrecuencia
                                        ,@IdBus
                                        ,@Habilitado
                                        ,@IdUsuarioH";
                cmd.Parameters.AddWithValue("Id", frecuenciaBusEntidad.Id);
                cmd.Parameters.AddWithValue("IdFrecuencia", frecuenciaBusEntidad.IdFrecuencia);
                cmd.Parameters.AddWithValue("IdBus", frecuenciaBusEntidad.IdBus);
                cmd.Parameters.AddWithValue("Habilitado", frecuenciaBusEntidad.Habilitado);
                cmd.Parameters.AddWithValue("IdUsuarioH", frecuenciaBusEntidad.IdUsuarioH);
                cmd.ExecuteNonQuery();
                connection.Close();
                return frecuenciaBusEntidad;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public static List<FrecuenciaBusEntidad> ListarFrecuenciasBus()
        {
            List<FrecuenciaBusEntidad> frecuenciaBusEntidads = new List<FrecuenciaBusEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarFrecuenciasBus";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    FrecuenciaBusEntidad frecuenciaBusEntidad = new FrecuenciaBusEntidad();
                    frecuenciaBusEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    frecuenciaBusEntidad.IdFrecuencia = Convert.ToInt32(dr["IdFrecuencia"].ToString());
                    frecuenciaBusEntidad.Frecuencia = dr["Frecuencia"].ToString();
                    frecuenciaBusEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                    frecuenciaBusEntidad.Bus = dr["Bus"].ToString();
                    frecuenciaBusEntidad.Habilitado = Convert.ToBoolean(dr["Habilitado"].ToString());
                    frecuenciaBusEntidad.IdUsuarioH = Convert.ToInt32(dr["IdUsuarioH"].ToString());
                    frecuenciaBusEntidad.UsuarioH = dr["UsuarioH"].ToString();

                    frecuenciaBusEntidads.Add(frecuenciaBusEntidad);
                }
            }
            connection.Close();
            return frecuenciaBusEntidads;

        }

        public static FrecuenciaBusEntidad ObtenerFrecuenciaBusPorId(int Id)
        {
            FrecuenciaBusEntidad frecuenciaBusEntidad = new FrecuenciaBusEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerFrecuenciaBusPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    frecuenciaBusEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    frecuenciaBusEntidad.IdFrecuencia = Convert.ToInt32(dr["IdFrecuencia"].ToString());
                    frecuenciaBusEntidad.Frecuencia = dr["Frecuencia"].ToString();
                    frecuenciaBusEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                    frecuenciaBusEntidad.Bus = dr["Bus"].ToString();
                    frecuenciaBusEntidad.Habilitado = Convert.ToBoolean(dr["Habilitado"].ToString());
                    frecuenciaBusEntidad.IdUsuarioH = Convert.ToInt32(dr["IdUsuarioH"].ToString());
                    frecuenciaBusEntidad.UsuarioH = dr["UsuarioH"].ToString();
                }


            }
            connection.Close();
            return frecuenciaBusEntidad;

        }

        public static bool Eliminar(int Id)
        {
            try
            {
                FrecuenciaBusEntidad frecuenciaBusEntidad = new FrecuenciaBusEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarFrecuenciaBus @Id";
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
