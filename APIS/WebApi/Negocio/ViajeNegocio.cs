using Datos;
using Entidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class ViajeNegocio
    {
        public static List<ViajeEntidad> BuscarViajes(FiltrosViaje filtrosViaje)
        {
            return ViajeDatos.BuscarViajes(filtrosViaje);
        }
        public static List<DetalleViajeEntidad> ListarDetalleViajePorIdViaje(int IdViaje)
        {
            return ViajeDatos.ListarDetalleViajePorIdViaje(IdViaje);

        }
        public static bool ReservarAsiento(int idUsuario, int idAsiento)
        {
            UsuarioEntidad usuario = UsuarioDatos.ObtenerUsuarioPorId(idUsuario);
            DetalleViajeEntidad detalle = ViajeDatos.ObtenerDetalleViajePorId(idAsiento);
            AsientoEntidad asiento = AsientoDatos.ObtenerAsientoPorId(detalle.IdAsiento);
            string asunto = "Reserva Asiento";
            string mensaje = "Estimado(a) :" + usuario.Nombre + " " + usuario.Apellido + "\n" +
                "Usted ha reservado el Asiento: " + detalle.Orden + "-" + detalle.DesAsiento + "\n" +
                "En el Bus: " + detalle.NumBus + " - Anio:" + detalle.Anio + " - Marca Chasis:" + detalle.MarcaCh + "\n" +
                "Cooperativa: " + detalle.Cooperativa + " - " + detalle.PaginaWeb + "  /" + detalle.Telefono + "\n" +
                "Tipo Asiento: " + detalle.Categoria + "\n" +
                "Precio Base: " + detalle.PrecioBase + "\n" +
                "Valor de Recargo: " + detalle.Recargo + "\n" +
                "Valor Total: " + detalle.PrecioFinal;
            string destinatario = usuario.Correo;
            EnvioCorreos.eviarCorreo(destinatario, asunto, mensaje);
            return ViajeDatos.ReservarAsiento(idAsiento);
        }
        public static bool CompraBoleto(ComprobanteEntidad comprobante)
        {
            UsuarioEntidad usuario = UsuarioDatos.ObtenerUsuarioPorId(comprobante.IdCliente);
            DetalleViajeEntidad detalle = ViajeDatos.ObtenerDetalleViajePorId(comprobante.IdAsientoViaje);
            AsientoEntidad asiento = AsientoDatos.ObtenerAsientoPorId(detalle.IdAsiento);
            string asunto = "Compra de Boleto";
            string mensaje = "Estimado(a) :" + usuario.Nombre + " " + usuario.Apellido + "\n" +
               "Usted ha reservado el Asiento: " + detalle.Orden + "-" + detalle.DesAsiento + "\n" +
               "Fecha de Salida:" + detalle.Fecha + "\n" +
               "Hora Salida" + detalle.HoraSalida + "\n\n" +
               "Detalles de Viaje \nBus: " + detalle.NumBus + " - Anio:" + detalle.Anio + " - Marca Chasis:" + detalle.MarcaCh + "\n" +
               "Cooperativa: " + detalle.Cooperativa + " - " + detalle.PaginaWeb + "  /" + detalle.Telefono + "\n" +
               "Tipo Asiento: " + detalle.Categoria + "\n" +
               "Precio Base: " + detalle.PrecioBase + "\n" +
               "Valor de Recargo: " + detalle.Recargo + "\n" +
               "Valor Total: " + detalle.PrecioFinal;
            string destinatario = usuario.Correo;
            EnvioCorreos.eviarCorreo(destinatario, asunto, mensaje);
            return ViajeDatos.CompraBoleto(comprobante);
        }
        public static bool CerrarViaje(int Id)
        {
            return ViajeDatos.CerrarViaje(Id);
        }
        public static bool CrearViajes(string fecha)
        {
            return ViajeDatos.CrearViajes(fecha);
        }
        public static bool CrearDetalleViajes()
        {
            return ViajeDatos.CrearDetalleViajes();
        }
        public static DetalleViajeEntidad ObtenerDetalleViajePorId(int Id)
        {
            return ViajeDatos.ObtenerDetalleViajePorId(Id);
        }
        public static List<FormaPago> ListaFormaPago()
        {
            return ViajeDatos.ListarFormaPago();
        }
        public static bool ConfirmarPago(ConfirmaPago confirma)
        {
            DetalleViajeEntidad detalle = ViajeDatos.ObtenerDetalleViajePorId(confirma.IdAsientoViaje);
            UsuarioEntidad usuario = UsuarioDatos.ObtenerUsuarioPorId(detalle.IdCliente);


            AsientoEntidad asiento = AsientoDatos.ObtenerAsientoPorId(detalle.IdAsiento);
            string asunto = "Confirmacion de Pago";
            string mensaje = "Estimado(a) :" + usuario.Nombre + " " + usuario.Apellido + "\n" +
               "Su pago ha sido Comprobado Satisfactoriamente: " + detalle.Orden + "-" + detalle.DesAsiento + "\n" +
               "Fecha de Salida:" + detalle.Fecha + "\n" +
               "Hora Salida" + detalle.HoraSalida + "\n\n" +
               "Detalles de Viaje \nBus: " + detalle.NumBus + " - Anio:" + detalle.Anio + " - Marca Chasis:" + detalle.MarcaCh + "\n" +
               "Cooperativa: " + detalle.Cooperativa + " - " + detalle.PaginaWeb + "  /" + detalle.Telefono + "\n" +
               "Tipo Asiento: " + detalle.Categoria + "\n" +
               "Precio Base: " + detalle.PrecioBase + "\n" +
               "Valor de Recargo: " + detalle.Recargo + "\n" +
               "Valor Total: " + detalle.PrecioFinal + "\n" +
               "ESTADO: " + confirma.Estado + "  \n" +
               "--" + confirma.Observacion;
            string destinatario = usuario.Correo;
            EnvioCorreos.eviarCorreo(destinatario, asunto, mensaje);
            return ViajeDatos.ConfirmarPago(confirma);
        }
        public static List<DetalleViajeEntidad> ListarDetalleViajePorEstado(string Estado, int IdCooperativa)
        {
            return ViajeDatos.ListarDetalleViajePorEstado(Estado, IdCooperativa);
        }
    }
}
