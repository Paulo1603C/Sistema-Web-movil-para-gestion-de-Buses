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
   
    public static class RolDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static RolEntidad Crear(RolEntidad rolEntidad)
        {
            try
            {
                SqlConnection connection= new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection= connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"sp_InsertarRol @Nombre, @Descripcion";
                cmd.Parameters.AddWithValue("@Nombre", rolEntidad.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", rolEntidad.Descripcion);
                int id= Convert.ToInt32(cmd.ExecuteScalar());
                rolEntidad.Id=id;
                connection.Close();
                return rolEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<RolEntidad> ListarRoles()
        {
            List<RolEntidad> rolEntidads= new List<RolEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarRoles";
            using (var dr= cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    RolEntidad rolEntidad = new RolEntidad();
                    rolEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    rolEntidad.Nombre = dr["Nombre"].ToString();
                    rolEntidad.Descripcion= dr["Descripcion"].ToString();

                    rolEntidads.Add(rolEntidad);
                }
            }
            connection.Close();
            return rolEntidads;

        }
        public static RolEntidad ObtenerRolPorId(int Id)
        {
            RolEntidad rolEntidad= new RolEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerRolPorId @Id";
            cmd.Parameters.AddWithValue("Id",Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    rolEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    rolEntidad.Nombre = dr["Nombre"].ToString();
                    rolEntidad.Descripcion = dr["Descripcion"].ToString();
                }
                

            }
            connection.Close();
            return rolEntidad;

        }

        public static RolEntidad Actualizar(RolEntidad rolEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarRol @Id, @Nombre, @Descripcion";
                cmd.Parameters.AddWithValue("Id", rolEntidad.Id);
                cmd.Parameters.AddWithValue("Nombre", rolEntidad.Nombre);
                cmd.Parameters.AddWithValue("Descripcion", rolEntidad.Descripcion);
                cmd.ExecuteNonQuery();
                connection.Close();
                return rolEntidad;

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
                RolEntidad rolEntidad = new RolEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarRol @Id";
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
