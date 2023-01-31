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
            AsientoEntidad asiento = AsientoDatos.ObtenerAsientoPorId(idAsiento);
            string asunto = "Reserva Asiento";
            string mensaje="Estimado(a) :"+usuario.Nombre+" "+usuario.Apellido+"Usted ha reservado el Asiento"+asiento.Orden+"-"+asiento.Descripcion;
            string destinatario = usuario.Correo;
            EnvioCorreos.eviarCorreo(destinatario,asunto,mensaje);
            return ViajeDatos.ReservarAsiento(idAsiento);
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
    }
}
