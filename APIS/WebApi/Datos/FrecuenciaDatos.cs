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
    public static class FrecuenciaDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static FrecuenciaEntidad Crear(FrecuenciaEntidad frecuenciaEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarFrecuencia
                                             @IdRuta
                                            ,@IdCooperativa
                                            ,@HoraSalida
                                            ,@HoraArribo
                                            ,@Habilitado
                                            ,@IdUsuarioH
                                            ,@DiaSemana
                                            ,@Precio";
                cmd.Parameters.AddWithValue("IdRuta", frecuenciaEntidad.IdRuta);
                cmd.Parameters.AddWithValue("IdCooperativa", frecuenciaEntidad.IdCooperativa);
                cmd.Parameters.AddWithValue("HoraSalida", frecuenciaEntidad.HoraSalida);
                cmd.Parameters.AddWithValue("HoraArribo", frecuenciaEntidad.HoraArribo);
                cmd.Parameters.AddWithValue("Habilitado", frecuenciaEntidad.Habilitado);
                cmd.Parameters.AddWithValue("IdUsuarioH", frecuenciaEntidad.IdUsuarioH);
                cmd.Parameters.AddWithValue("DiaSemana", frecuenciaEntidad.DiaSemana);
                cmd.Parameters.AddWithValue("Precio", frecuenciaEntidad.Precio);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                frecuenciaEntidad.Id = id;
                connection.Close();
                return frecuenciaEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static FrecuenciaEntidad Actualizar(FrecuenciaEntidad frecuenciaEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarFrecuencia 
                                        @Id
                                        ,@IdRuta
                                        ,@IdCooperativa
                                        ,@HoraSalida
                                        ,@HoraArribo
                                        ,@Habilitado
                                        ,@IdUsuarioH
                                        ,@DiaSemana
                                        ,@Precio";
                cmd.Parameters.AddWithValue("Id", frecuenciaEntidad.Id);
                cmd.Parameters.AddWithValue("IdRuta", frecuenciaEntidad.IdRuta);
                cmd.Parameters.AddWithValue("IdCooperativa", frecuenciaEntidad.IdCooperativa);
                cmd.Parameters.AddWithValue("HoraSalida", frecuenciaEntidad.HoraSalida);
                cmd.Parameters.AddWithValue("HoraArribo", frecuenciaEntidad.HoraArribo);
                cmd.Parameters.AddWithValue("Habilitado", frecuenciaEntidad.Habilitado);
                cmd.Parameters.AddWithValue("IdUsuarioH", frecuenciaEntidad.IdUsuarioH);
                cmd.Parameters.AddWithValue("DiaSemana", frecuenciaEntidad.DiaSemana);
                cmd.Parameters.AddWithValue("Precio", frecuenciaEntidad.Precio);
                cmd.ExecuteNonQuery();
                connection.Close();
                return frecuenciaEntidad;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public static List<FrecuenciaEntidad> ListarFrecuencias()
        {
            List<FrecuenciaEntidad> frecuenciaEntidads = new List<FrecuenciaEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarFrecuencias";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    FrecuenciaEntidad frecuenciaEntidad = new FrecuenciaEntidad();
                    frecuenciaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    frecuenciaEntidad.IdRuta = Convert.ToInt32(dr["IdRuta"].ToString());
                    frecuenciaEntidad.Ruta = dr["Ruta"].ToString();
                    frecuenciaEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    frecuenciaEntidad.Cooperativa = dr["Cooperativa"].ToString();
                    frecuenciaEntidad.HoraSalida = dr["HoraSalida"].ToString();
                    frecuenciaEntidad.HoraArribo = dr["HoraArribo"].ToString();
                    frecuenciaEntidad.Habilitado = Convert.ToBoolean(dr["Habilitado"].ToString());
                    frecuenciaEntidad.IdUsuarioH = Convert.ToInt32(dr["IdUsuarioH"].ToString());
                    frecuenciaEntidad.UsuarioH = dr["UsuarioH"].ToString();
                    frecuenciaEntidad.DiaSemana = dr["DiaSemana"].ToString();
                    frecuenciaEntidad.Precio = Convert.ToDecimal(dr["Precio"].ToString());

                    frecuenciaEntidads.Add(frecuenciaEntidad);
                }
            }
            connection.Close();
            return frecuenciaEntidads;

        }

        public static FrecuenciaEntidad ObtenerFrecuenciaPorId(int Id)
        {
            FrecuenciaEntidad frecuenciaEntidad = new FrecuenciaEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerFrecuenciaPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    frecuenciaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    frecuenciaEntidad.IdRuta = Convert.ToInt32(dr["IdRuta"].ToString());
                    frecuenciaEntidad.Ruta = dr["Ruta"].ToString();
                    frecuenciaEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    frecuenciaEntidad.Cooperativa = dr["Cooperativa"].ToString();
                    frecuenciaEntidad.HoraSalida = dr["HoraSalida"].ToString();
                    frecuenciaEntidad.HoraArribo = dr["HoraArribo"].ToString();
                    frecuenciaEntidad.Habilitado = Convert.ToBoolean(dr["Habilitado"].ToString());
                    frecuenciaEntidad.IdUsuarioH = Convert.ToInt32(dr["IdUsuarioH"].ToString());
                    frecuenciaEntidad.UsuarioH = dr["UsuarioH"].ToString();
                    frecuenciaEntidad.DiaSemana = dr["DiaSemana"].ToString();
                    frecuenciaEntidad.Precio = Convert.ToDecimal(dr["Precio"].ToString());
                }


            }
            connection.Close();
            return frecuenciaEntidad;

        }

        public static bool Eliminar(int Id)
        {
            try
            {
                FrecuenciaEntidad frecuenciaEntidad = new FrecuenciaEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarFrecuencia @Id";
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
        public static bool HabilitarFrecuencia(string IdFrecuencia, string IdUsuario)
        {
            try
            {
                FrecuenciaEntidad frecuenciaEntidad = new FrecuenciaEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_HabilitarFrecuencia @Id, @IdUsuario";
                cmd.Parameters.AddWithValue("@Id", IdFrecuencia);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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
