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
    public static class CooperativaDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static CooperativaEntidad Crear(CooperativaEntidad cooperativaEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarCooperativa
                                                             @Nombre
                                                            ,@Representante
                                                            ,@Telefono
                                                            ,@Correo
                                                            ,@PaginaWeb";
                cmd.Parameters.AddWithValue("Nombre", cooperativaEntidad.Nombre);
                cmd.Parameters.AddWithValue("Representante", cooperativaEntidad.Representante);
                cmd.Parameters.AddWithValue("Telefono", cooperativaEntidad.Telefono);
                cmd.Parameters.AddWithValue("Correo", cooperativaEntidad.Correo);
                cmd.Parameters.AddWithValue("PaginaWeb", cooperativaEntidad.PaginaWeb);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                cooperativaEntidad.Id = id;
                connection.Close();
                return cooperativaEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static List<CooperativaEntidad> ListarCooperativas()
        {
            List<CooperativaEntidad> cooperativaEntidads = new List<CooperativaEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarCooperativas";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    CooperativaEntidad cooperativaEntidad = new CooperativaEntidad();
                    cooperativaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    cooperativaEntidad.Nombre = dr["Nombre"].ToString();
                    cooperativaEntidad.Representante = dr["Representante"].ToString();
                    cooperativaEntidad.Telefono = dr["Telefono"].ToString();
                    cooperativaEntidad.Correo = dr["Correo"].ToString();
                    cooperativaEntidad.PaginaWeb = dr["PaginaWeb"].ToString();

                    cooperativaEntidads.Add(cooperativaEntidad);
                }
            }
            connection.Close();
            return cooperativaEntidads;

        }
        
        public static CooperativaEntidad ObtenerCooperativaPorId(int Id)
        {
            CooperativaEntidad cooperativaEntidad = new CooperativaEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerCooperativaPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    cooperativaEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    cooperativaEntidad.Nombre = dr["Nombre"].ToString();
                    cooperativaEntidad.Representante = dr["Representante"].ToString();
                    cooperativaEntidad.Telefono = dr["Telefono"].ToString();
                    cooperativaEntidad.Correo = dr["Correo"].ToString();
                    cooperativaEntidad.PaginaWeb = dr["PaginaWeb"].ToString();
                }


            }
            connection.Close();
            return cooperativaEntidad;

        }

        public static CooperativaEntidad Actualizar(CooperativaEntidad cooperativaEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarCooperativa 
                                        @Id,
                                        @Nombre,
                                        @Representante,
                                        @Telefono,
                                        @Correo,
                                        @PaginaWeb";
                cmd.Parameters.AddWithValue("Id", cooperativaEntidad.Id);
                cmd.Parameters.AddWithValue("Nombre", cooperativaEntidad.Nombre);
                cmd.Parameters.AddWithValue("Representante", cooperativaEntidad.Representante);
                cmd.Parameters.AddWithValue("Telefono", cooperativaEntidad.Telefono);
                cmd.Parameters.AddWithValue("Correo", cooperativaEntidad.Correo);
                cmd.Parameters.AddWithValue("PaginaWeb", cooperativaEntidad.PaginaWeb);
                cmd.ExecuteNonQuery();
                connection.Close();
                return cooperativaEntidad;

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
                CooperativaEntidad cooperativaEntidad = new CooperativaEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarCooperativa @Id";
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
