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
    public static class UsuarioDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static UsuarioEntidad Crear(UsuarioEntidad usuarioEntidad)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_InsertarUsuario
                                                               @Nombre
                                                              ,@Apellido
                                                              ,@TipoIdentificacion
                                                              ,@NumeroIdentificacion
                                                              ,@Telefono
                                                              ,@Correo
                                                              ,@Direccion
                                                              ,@Usuario
                                                              ,@Password
                                                              ,@IdRol";
                cmd.Parameters.AddWithValue("Nombre", usuarioEntidad.Nombre);
                cmd.Parameters.AddWithValue("Apellido", usuarioEntidad.Apellido);
                cmd.Parameters.AddWithValue("TipoIdentificacion", usuarioEntidad.TipoIdentificacion);
                cmd.Parameters.AddWithValue("NumeroIdentificacion", usuarioEntidad.NumeroIdentificacion);
                cmd.Parameters.AddWithValue("Telefono", usuarioEntidad.Telefono);
                cmd.Parameters.AddWithValue("Correo", usuarioEntidad.Correo);
                cmd.Parameters.AddWithValue("Direccion", usuarioEntidad.Direccion);
                cmd.Parameters.AddWithValue("Usuario", usuarioEntidad.Usuario);
                cmd.Parameters.AddWithValue("Password", usuarioEntidad.Password);
                cmd.Parameters.AddWithValue("IdRol", usuarioEntidad.IdRol);
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                usuarioEntidad.Id = id;
                connection.Close();
                return usuarioEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<UsuarioEntidad> ListarUsuarios()
        {
            List<UsuarioEntidad> usuarioEntidads = new List<UsuarioEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarUsuarios";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    UsuarioEntidad usuarioEntidad = new UsuarioEntidad();
                    usuarioEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    usuarioEntidad.Nombre = dr["Nombre"].ToString();
                    usuarioEntidad.Apellido = dr["Apellido"].ToString();
                    usuarioEntidad.TipoIdentificacion = dr["TipoIdentificacion"].ToString();
                    usuarioEntidad.NumeroIdentificacion = dr["NumeroIdentificacion"].ToString();
                    usuarioEntidad.Telefono = dr["Telefono"].ToString();
                    usuarioEntidad.Correo = dr["Correo"].ToString();
                    usuarioEntidad.Direccion = dr["Direccion"].ToString();
                    usuarioEntidad.Usuario = dr["Usuario"].ToString();
                    usuarioEntidad.Password = dr["Password"].ToString();
                    usuarioEntidad.IdRol = Convert.ToInt32(dr["IdRol"].ToString());
                    usuarioEntidad.Rol = dr["Rol"].ToString();

                    usuarioEntidads.Add(usuarioEntidad);
                }
            }
            connection.Close();
            return usuarioEntidads;

        }
        public static UsuarioEntidad ObtenerUsuarioPorId(int Id)
        {
            UsuarioEntidad usuarioEntidad = new UsuarioEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerUsuarioPorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    usuarioEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    usuarioEntidad.Nombre = dr["Nombre"].ToString();
                    usuarioEntidad.Apellido = dr["Apellido"].ToString();
                    usuarioEntidad.TipoIdentificacion = dr["TipoIdentificacion"].ToString();
                    usuarioEntidad.NumeroIdentificacion = dr["NumeroIdentificacion"].ToString();
                    usuarioEntidad.Telefono = dr["Telefono"].ToString();
                    usuarioEntidad.Correo = dr["Correo"].ToString();
                    usuarioEntidad.Direccion = dr["Direccion"].ToString();
                    usuarioEntidad.Usuario = dr["Usuario"].ToString();
                    usuarioEntidad.Password = dr["Password"].ToString();
                    usuarioEntidad.IdRol = Convert.ToInt32(dr["IdRol"].ToString());
                    usuarioEntidad.Rol = dr["Rol"].ToString();
                }


            }
            connection.Close();
            return usuarioEntidad;

        }
        public static UsuarioEntidad ObtenerUsuarioLogin(LoginEntidad loginEntidad)
        {
            UsuarioEntidad usuarioEntidad = new UsuarioEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerUsuarioLogin @userName, @password";
            cmd.Parameters.AddWithValue("userName", loginEntidad.UserName);
            cmd.Parameters.AddWithValue("password", loginEntidad.Password);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    usuarioEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    usuarioEntidad.Nombre = dr["Nombre"].ToString();
                    usuarioEntidad.Apellido = dr["Apellido"].ToString();
                    usuarioEntidad.TipoIdentificacion = dr["TipoIdentificacion"].ToString();
                    usuarioEntidad.NumeroIdentificacion = dr["NumeroIdentificacion"].ToString();
                    usuarioEntidad.Telefono = dr["Telefono"].ToString();
                    usuarioEntidad.Correo = dr["Correo"].ToString();
                    usuarioEntidad.Direccion = dr["Direccion"].ToString();
                    usuarioEntidad.Usuario = dr["Usuario"].ToString();
                    usuarioEntidad.Password = dr["Password"].ToString();
                    usuarioEntidad.IdRol = Convert.ToInt32(dr["IdRol"].ToString());
                    usuarioEntidad.Rol = dr["Rol"].ToString();
                }
                else
                {
                    return null;
                }


            }
            connection.Close();
            return usuarioEntidad;

        }

        public static UsuarioEntidad Actualizar(UsuarioEntidad usuarioEntidad)
        {

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"EXEC sp_ActualizarUsuario 
                                         @Id
                                        ,@Nombre
                                        ,@Apellido
                                        ,@TipoIdentificacion
                                        ,@NumeroIdentificacion
                                        ,@Telefono
                                        ,@Correo
                                        ,@Direccion
                                        ,@Usuario
                                        ,@Password
                                        ,@IdRol";
                cmd.Parameters.AddWithValue("Id", usuarioEntidad.Id);
                cmd.Parameters.AddWithValue("Nombre", usuarioEntidad.Nombre);
                cmd.Parameters.AddWithValue("Apellido", usuarioEntidad.Apellido);
                cmd.Parameters.AddWithValue("TipoIdentificacion", usuarioEntidad.TipoIdentificacion);
                cmd.Parameters.AddWithValue("NumeroIdentificacion", usuarioEntidad.NumeroIdentificacion);
                cmd.Parameters.AddWithValue("Telefono", usuarioEntidad.Telefono);
                cmd.Parameters.AddWithValue("Correo", usuarioEntidad.Correo);
                cmd.Parameters.AddWithValue("Direccion", usuarioEntidad.Direccion);
                cmd.Parameters.AddWithValue("Usuario", usuarioEntidad.Usuario);
                cmd.Parameters.AddWithValue("Password", usuarioEntidad.Password);
                cmd.Parameters.AddWithValue("IdRol", usuarioEntidad.IdRol);
                cmd.ExecuteNonQuery();
                connection.Close();
                return usuarioEntidad;

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
                UsuarioEntidad usuarioEntidad = new UsuarioEntidad();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_EliminarUsuario @Id";
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
