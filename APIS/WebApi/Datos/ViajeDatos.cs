using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class ViajeDatos
    {
        public static string cadenaConexion = PropiedadesConeccion.cadenaConexion;
        public static List<ViajeEntidad> BuscarViajes(FiltrosViaje filtrosViaje)
        {
            try
            {
                
                List <ViajeEntidad> viajesEntidad = new List<ViajeEntidad>();
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_BuscarViajes
                                            @Origen,
                                            @Destino,
                                            @Fecha,
                                            @Cooperativa,
                                            @Categoria";
                if (filtrosViaje.Origen == null) 
                    cmd.Parameters.AddWithValue("Origen", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("Origen", filtrosViaje.Origen);
                if (filtrosViaje.Destino == null)
                    cmd.Parameters.AddWithValue("Destino",DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("Destino", filtrosViaje.Destino);
                if (filtrosViaje.Fecha == null)
                    cmd.Parameters.AddWithValue("Fecha", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("Fecha", filtrosViaje.Fecha);
                if (filtrosViaje.Cooperativa == null)
                    cmd.Parameters.AddWithValue("Cooperativa",DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("Cooperativa", filtrosViaje.Cooperativa);
                if (filtrosViaje.Categoria == null)
                    cmd.Parameters.AddWithValue("Categoria", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("Categoria", filtrosViaje.Categoria);


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ViajeEntidad viajeEntidad = new ViajeEntidad();
                        viajeEntidad.IdViaje = Convert.ToInt32(dr["IdViaje"].ToString());
                        viajeEntidad.Fecha = dr["Fecha"].ToString();
                        viajeEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                        viajeEntidad.Cooperativa = dr["Cooperativa"].ToString();
                        viajeEntidad.Representante = dr["Representante"].ToString();
                        viajeEntidad.PaginaWeb = dr["PaginaWeb"].ToString();
                        viajeEntidad.Telefono = dr["Telefono"].ToString();
                        viajeEntidad.IdFrecuencia = Convert.ToInt32(dr["IdFrecuencia"].ToString());
                        viajeEntidad.HoraSalida = dr["HoraSalida"].ToString();
                        viajeEntidad.HoraArribo = dr["HoraArribo"].ToString();
                        viajeEntidad.IdRuta = Convert.ToInt32(dr["IdRuta"].ToString());
                        viajeEntidad.Origen = dr["Origen"].ToString();
                        viajeEntidad.Destino = dr["Destino"].ToString();
                        viajeEntidad.NumAsientosDisponibles = Convert.ToInt32(dr["NumAsientosDisponibles"].ToString());
                        viajeEntidad.NumParadas = Convert.ToInt32(dr["NumParadas"].ToString());
                        viajeEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                        viajeEntidad.Anio = Convert.ToInt32(dr["Anio"].ToString());
                        viajeEntidad.Capacidad = Convert.ToInt32(dr["Capacidad"].ToString());
                        viajeEntidad.MarcaCh = dr["MarcaCh"].ToString();
                        viajeEntidad.Numero = dr["Numero"].ToString();
                        viajeEntidad.RamvCpn = dr["RamvCpn"].ToString();
                        viajeEntidad.Precio = Convert.ToDecimal(dr["Precio"].ToString());

                        viajesEntidad.Add(viajeEntidad);
                    }
                }
                return viajesEntidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<DetalleViajeEntidad> ListarDetalleViajePorIdViaje(int IdViaje)
        {
            List<DetalleViajeEntidad> detalleViajeEntidads = new List<DetalleViajeEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarDetalleViajePorIdViaje @Id";
            cmd.Parameters.AddWithValue("Id", IdViaje);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    DetalleViajeEntidad detalleViajeEntidad = new DetalleViajeEntidad();
                    detalleViajeEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    detalleViajeEntidad.IdViaje = Convert.ToInt32(dr["IdViaje"].ToString());
                    detalleViajeEntidad.IdAsiento = Convert.ToInt32(dr["IdAsiento"].ToString());
                    detalleViajeEntidad.Estado = dr["Estado"].ToString();
                    detalleViajeEntidad.Orden = Convert.ToInt32(dr["Orden"].ToString());
                    detalleViajeEntidad.DesAsiento = dr["DesAsiento"].ToString();
                    detalleViajeEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                    detalleViajeEntidad.NumBus = dr["NumBus"].ToString();
                    detalleViajeEntidad.Anio = Convert.ToInt32(dr["Anio"].ToString());
                    detalleViajeEntidad.MarcaCh = dr["MarcaCh"].ToString();
                    detalleViajeEntidad.ModeloCar = dr["ModeloCar"].ToString();
                    detalleViajeEntidad.Pisos = Convert.ToInt32(dr["Pisos"].ToString());
                    detalleViajeEntidad.RamvCpn = dr["RamvCpn"].ToString();
                    detalleViajeEntidad.RutaImagen = dr["RutaImagen"].ToString();
                    detalleViajeEntidad.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    detalleViajeEntidad.Categoria = dr["Categoria"].ToString();
                    detalleViajeEntidad.Recargo = Convert.ToDecimal(dr["Recargo"].ToString());
                    detalleViajeEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    detalleViajeEntidad.Cooperativa = dr["Cooperativa"].ToString();
                    detalleViajeEntidad.Telefono = dr["Telefono"].ToString();
                    detalleViajeEntidad.PaginaWeb = dr["PaginaWeb"].ToString();
                    detalleViajeEntidad.PrecioBase = Convert.ToDecimal(dr["PrecioBase"].ToString());
                    detalleViajeEntidad.PrecioFinal = Convert.ToDecimal(dr["PrecioFinal"].ToString());
                    detalleViajeEntidad.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                    detalleViajeEntidad.HoraSalida = dr["HoraSalida"].ToString();
                    detalleViajeEntidad.IdCliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    detalleViajeEntidad.Cliente = dr["Cliente"].ToString();
                    detalleViajeEntidad.Evidencia = dr["Evidencia"].ToString();
                    detalleViajeEntidad.IdFormaPago = Convert.ToInt32(dr["IdFormaPago"].ToString());
                    detalleViajeEntidad.FormaPago = dr["FormaPago"].ToString();
                    detalleViajeEntidad.IdUsuarioConfirma = Convert.ToInt32(dr["IdUsuarioConfirma"].ToString());
                    detalleViajeEntidad.UsuarioConfirma = dr["UsuarioConfirma"].ToString();
                    detalleViajeEntidad.Observacion = dr["Observacion"].ToString();

                    detalleViajeEntidads.Add(detalleViajeEntidad);
                }
            }
            return detalleViajeEntidads;

        }
        public static List<DetalleViajeEntidad> ListarDetalleViajePorEstado(string Estado, int IdCooperativa)
        {
            List<DetalleViajeEntidad> detalleViajeEntidads = new List<DetalleViajeEntidad>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarDetalleViajePorEstado @Estado, @IdCooperativa";
            cmd.Parameters.AddWithValue("Estado", Estado);
            cmd.Parameters.AddWithValue("IdCooperativa", IdCooperativa);
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    DetalleViajeEntidad detalleViajeEntidad = new DetalleViajeEntidad();
                    detalleViajeEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    detalleViajeEntidad.IdViaje = Convert.ToInt32(dr["IdViaje"].ToString());
                    detalleViajeEntidad.IdAsiento = Convert.ToInt32(dr["IdAsiento"].ToString());
                    detalleViajeEntidad.Estado = dr["Estado"].ToString();
                    detalleViajeEntidad.Orden = Convert.ToInt32(dr["Orden"].ToString());
                    detalleViajeEntidad.DesAsiento = dr["DesAsiento"].ToString();
                    detalleViajeEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                    detalleViajeEntidad.NumBus = dr["NumBus"].ToString();
                    detalleViajeEntidad.Anio = Convert.ToInt32(dr["Anio"].ToString());
                    detalleViajeEntidad.MarcaCh = dr["MarcaCh"].ToString();
                    detalleViajeEntidad.ModeloCar = dr["ModeloCar"].ToString();
                    detalleViajeEntidad.Pisos = Convert.ToInt32(dr["Pisos"].ToString());
                    detalleViajeEntidad.RamvCpn = dr["RamvCpn"].ToString();
                    detalleViajeEntidad.RutaImagen = dr["RutaImagen"].ToString();
                    detalleViajeEntidad.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    detalleViajeEntidad.Categoria = dr["Categoria"].ToString();
                    detalleViajeEntidad.Recargo = Convert.ToDecimal(dr["Recargo"].ToString());
                    detalleViajeEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    detalleViajeEntidad.Cooperativa = dr["Cooperativa"].ToString();
                    detalleViajeEntidad.Telefono = dr["Telefono"].ToString();
                    detalleViajeEntidad.PaginaWeb = dr["PaginaWeb"].ToString();
                    detalleViajeEntidad.PrecioBase = Convert.ToDecimal(dr["PrecioBase"].ToString());
                    detalleViajeEntidad.PrecioFinal = Convert.ToDecimal(dr["PrecioFinal"].ToString());
                    detalleViajeEntidad.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                    detalleViajeEntidad.HoraSalida = dr["HoraSalida"].ToString();
                    detalleViajeEntidad.IdCliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    detalleViajeEntidad.Cliente = dr["Cliente"].ToString();
                    detalleViajeEntidad.Evidencia = dr["Evidencia"].ToString();
                    detalleViajeEntidad.IdFormaPago = Convert.ToInt32(dr["IdFormaPago"].ToString());
                    detalleViajeEntidad.FormaPago = dr["FormaPago"].ToString();
                    detalleViajeEntidad.IdUsuarioConfirma = Convert.ToInt32(dr["IdUsuarioConfirma"].ToString());
                    detalleViajeEntidad.UsuarioConfirma = dr["UsuarioConfirma"].ToString();
                    detalleViajeEntidad.Observacion = dr["Observacion"].ToString();

                    detalleViajeEntidads.Add(detalleViajeEntidad);
                }
            }
            return detalleViajeEntidads;

        }
        public static bool ReservarAsiento(int Id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_ReservarAsiento @Id";
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
        
        public static bool CerrarViaje(int Id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_CerrarViaje @Id";
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
        public static bool CrearViajes(string fecha)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_CrearViajes @Fecha";
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool CrearDetalleViajes()
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_CrearDetallesViajes";
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool CompraBoleto(ComprobanteEntidad comprobante)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_CompraBoleto 
                                                        @Id, 
                                                        @IdCliente,
                                                        @IdFormaPago,
                                                        @Comprobante,
                                                        @ValorPagado,
                                                        @Imagen";
                cmd.Parameters.AddWithValue("@Id", comprobante.IdAsientoViaje);
                cmd.Parameters.AddWithValue("@IdCliente", comprobante.IdCliente);
                if (comprobante.IdFormaPago == null)
                    cmd.Parameters.AddWithValue("@IdFormaPago", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IdFormaPago", comprobante.IdFormaPago);

                if (comprobante.Comprobante == null)
                    cmd.Parameters.AddWithValue("@Comprobante", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Comprobante", comprobante.RutaComprobante);

                if (comprobante.ValorPagado == null)
                    cmd.Parameters.AddWithValue("@ValorPagado", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ValorPagado", comprobante.ValorPagado);



                if (comprobante.Comprobante == null)
                {
                    cmd.Parameters.AddWithValue("@Imagen", DBNull.Value);
                }
                   
                else {
                    using (var ms = new System.IO.MemoryStream())
                    {
                        comprobante.Comprobante.CopyTo(ms);                        
                        cmd.Parameters.AddWithValue("@Imagen", ms.ToArray());
                    }
                   
                }
                    


                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DetalleViajeEntidad ObtenerDetalleViajePorId(int Id)
        {
            DetalleViajeEntidad detalleViajeEntidad = new DetalleViajeEntidad();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ObtenerDetalleViajePorId @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            using (var dr = cmd.ExecuteReader())
            {
                dr.Read();
                if (dr.HasRows)
                {
                    detalleViajeEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    detalleViajeEntidad.IdViaje = Convert.ToInt32(dr["IdViaje"].ToString());
                    detalleViajeEntidad.IdAsiento = Convert.ToInt32(dr["IdAsiento"].ToString());
                    detalleViajeEntidad.Estado = dr["Estado"].ToString();
                    detalleViajeEntidad.Orden = Convert.ToInt32(dr["Orden"].ToString());
                    detalleViajeEntidad.DesAsiento = dr["DesAsiento"].ToString();
                    detalleViajeEntidad.IdBus = Convert.ToInt32(dr["IdBus"].ToString());
                    detalleViajeEntidad.NumBus = dr["NumBus"].ToString();
                    detalleViajeEntidad.Anio = Convert.ToInt32(dr["Anio"].ToString());
                    detalleViajeEntidad.MarcaCh = dr["MarcaCh"].ToString();
                    detalleViajeEntidad.ModeloCar = dr["ModeloCar"].ToString();
                    detalleViajeEntidad.Pisos = Convert.ToInt32(dr["Pisos"].ToString());
                    detalleViajeEntidad.RamvCpn = dr["RamvCpn"].ToString();
                    detalleViajeEntidad.RutaImagen = dr["RutaImagen"].ToString();
                    detalleViajeEntidad.IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString());
                    detalleViajeEntidad.Categoria = dr["Categoria"].ToString();
                    detalleViajeEntidad.Recargo = Convert.ToDecimal(dr["Recargo"].ToString());
                    detalleViajeEntidad.IdCooperativa = Convert.ToInt32(dr["IdCooperativa"].ToString());
                    detalleViajeEntidad.Cooperativa = dr["Cooperativa"].ToString();
                    detalleViajeEntidad.Telefono = dr["Telefono"].ToString();
                    detalleViajeEntidad.PaginaWeb = dr["PaginaWeb"].ToString();
                    detalleViajeEntidad.PrecioBase = Convert.ToDecimal(dr["PrecioBase"].ToString());
                    detalleViajeEntidad.PrecioFinal = Convert.ToDecimal(dr["PrecioFinal"].ToString());
                    detalleViajeEntidad.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                    detalleViajeEntidad.HoraSalida = dr["HoraSalida"].ToString();
                    detalleViajeEntidad.IdCliente = Convert.ToInt32(dr["IdCliente"].ToString());
                    detalleViajeEntidad.Cliente = dr["Cliente"].ToString();
                    detalleViajeEntidad.Evidencia = dr["Evidencia"].ToString();
                    detalleViajeEntidad.IdFormaPago = Convert.ToInt32(dr["IdFormaPago"].ToString());
                    detalleViajeEntidad.FormaPago = dr["FormaPago"].ToString();
                    detalleViajeEntidad.IdUsuarioConfirma = Convert.ToInt32(dr["IdUsuarioConfirma"].ToString());
                    detalleViajeEntidad.UsuarioConfirma = dr["UsuarioConfirma"].ToString();
                    detalleViajeEntidad.Observacion = dr["Observacion"].ToString();
                    detalleViajeEntidad.Imagen = dr.GetSqlBytes(33).Buffer;

                }
            }
            return detalleViajeEntidad;

        }
        public static List<FormaPago> ListarFormaPago()
        {
            List<FormaPago> fpEntidads = new List<FormaPago>();
            SqlConnection connection = new SqlConnection(cadenaConexion);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"EXEC sp_ListarFormaPago";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    FormaPago fpEntidad = new FormaPago();
                    fpEntidad.Id = Convert.ToInt32(dr["Id"].ToString());
                    fpEntidad.Nombre = dr["Nombre"].ToString();
                    fpEntidad.Descripcion = dr["Descripcion"].ToString();

                    fpEntidads.Add(fpEntidad);
                }
            }
            connection.Close();
            return fpEntidads;

        }
        public static bool ConfirmarPago(ConfirmaPago confirma)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"exec sp_ConfirmaPago 
                                                        @Id, 
                                                        @IdUsuario,
                                                        @Estado,
                                                        @Observacion";
                cmd.Parameters.AddWithValue("@Id", confirma.IdAsientoViaje);
                cmd.Parameters.AddWithValue("@IdUsuario", confirma.IdUsuario);
                cmd.Parameters.AddWithValue("@Estado", confirma.Estado);
                if (confirma.Observacion == null)
                    cmd.Parameters.AddWithValue("@Observacion", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Observacion", confirma.Observacion);


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
