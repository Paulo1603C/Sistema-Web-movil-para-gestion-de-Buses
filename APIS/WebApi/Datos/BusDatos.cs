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
    public static class BusDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static BusEntidad Crear(BusEntidad busEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarBus
                                             @IdCooperativa
                                            ,@Numero
                                            ,@Anio
                                            ,@RamvCpn
                                            ,@ModeloCar
                                            ,@MarcaCh
                                            ,@Transporte
                                            ,@Pisos
                                            ,@Capacidad
                                            ,@Puertas
                                            ,@RutaImagen";
                cmd.Parameters.AddWithValue("IdCooperativa", busEntidad.IdCooperativa);
                cmd.Parameters.AddWithValue("Numero", busEntidad.Numero);
                cmd.Parameters.AddWithValue("Anio", busEntidad.Anio);
                cmd.Parameters.AddWithValue("RamvCpn", busEntidad.RamvCpn);
                cmd.Parameters.AddWithValue("ModeloCar", busEntidad.ModeloCar);
                cmd.Parameters.AddWithValue("MarcaCh", busEntidad.MarcaCh);
                cmd.Parameters.AddWithValue("Transporte", busEntidad.Transporte);
                cmd.Parameters.AddWithValue("Pisos", busEntidad.Pisos);
                cmd.Parameters.AddWithValue("Capacidad", busEntidad.Capacidad);
                cmd.Parameters.AddWithValue("Puertas", busEntidad.Puertas);
                cmd.Parameters.AddWithValue("RutaImagen", busEntidad.RutaImagen);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                busEntidad.Id = id;
                connection.Close();
                return busEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static BusEntidad Actualizar(BusEntidad busEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarBus 
                                        @Id
                                        ,@IdCooperativa
                                        ,@Numero
                                        ,@Anio
                                        ,@RamvCpn
                                        ,@ModeloCar
                                        ,@MarcaCh
                                        ,@Transporte
                                        ,@Pisos
                                        ,@Capacidad
                                        ,@Puertas
                                        ,@RutaImagen";
                cmd.Parameters.AddWithValue("Id", busEntidad.Id);
                cmd.Parameters.AddWithValue("IdCooperativa", busEntidad.IdCooperativa);
                cmd.Parameters.AddWithValue("Numero", busEntidad.Numero);
                cmd.Parameters.AddWithValue("Anio", busEntidad.Anio);
                cmd.Parameters.AddWithValue("RamvCpn", busEntidad.RamvCpn);
                cmd.Parameters.AddWithValue("ModeloCar", busEntidad.ModeloCar);
                cmd.Parameters.AddWithValue("MarcaCh", busEntidad.MarcaCh);
                cmd.Parameters.AddWithValue("Transporte", busEntidad.Transporte);
                cmd.Parameters.AddWithValue("Pisos", busEntidad.Pisos);
                cmd.Parameters.AddWithValue("Capacidad", busEntidad.Capacidad);
                cmd.Parameters.AddWithValue("Puertas", busEntidad.Puertas);
                cmd.Parameters.AddWithValue("RutaImagen", busEntidad.RutaImagen);
                cmd.ExecuteNonQuery();
                connection.Close();
                return busEntidad;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public static List<BusEntidad> ListarBuses()
        {
            List<BusEntidad> busEntidads = new List<BusEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarBuses";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    BusEntidad busEntidad = new BusEntidad();
                    busEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    busEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    busEntidad.Cooperativa = dr["Cooperativa"].ToString();
                    busEntidad.Numero = dr["Numero"].ToString();
                    busEntidad.Anio = Convert.ToInt32(dr["Anio"].ToString());
                    busEntidad.RamvCpn = dr["RamvCpn"].ToString();
                    busEntidad.ModeloCar = dr["ModeloCar"].ToString();
                    busEntidad.MarcaCh = dr["MarcaCh"].ToString();
                    busEntidad.Transporte = dr["Transporte"].ToString();
                    busEntidad.Pisos = Convert.ToInt32(dr["Pisos"].ToString());
                    busEntidad.Capacidad = Convert.ToInt32(dr["Capacidad"].ToString());
                    busEntidad.Puertas = Convert.ToInt32(dr["Puertas"].ToString());
                    busEntidad.RutaImagen = dr["RutaImagen"].ToString();

                    busEntidads.Add(busEntidad);
                }
            }
            connection.Close();
            return busEntidads;

        }

        public static BusEntidad ObtenerBusPorId(int Id)
        {
            BusEntidad busEntidad = new BusEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerBusPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    busEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    busEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    busEntidad.Cooperativa = dr["Cooperativa"].ToString();
                    busEntidad.Numero = dr["Numero"].ToString();
                    busEntidad.Anio = Convert.ToInt32(dr["Anio"].ToString());
                    busEntidad.RamvCpn = dr["RamvCpn"].ToString();
                    busEntidad.ModeloCar = dr["ModeloCar"].ToString();
                    busEntidad.MarcaCh = dr["MarcaCh"].ToString();
                    busEntidad.Transporte = dr["Transporte"].ToString();
                    busEntidad.Pisos = Convert.ToInt32(dr["Pisos"].ToString());
                    busEntidad.Capacidad = Convert.ToInt32(dr["Capacidad"].ToString());
                    busEntidad.Puertas = Convert.ToInt32(dr["Puertas"].ToString());
                    busEntidad.RutaImagen = dr["RutaImagen"].ToString();
                }


            }
            connection.Close();
            return busEntidad;

        }

        public static bool Eliminar(int Id)
        {
            try
            {
                BusEntidad busEntidad = new BusEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarBus @Id";
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
