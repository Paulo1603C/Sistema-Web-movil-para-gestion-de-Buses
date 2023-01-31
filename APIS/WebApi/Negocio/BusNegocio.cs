using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class BusNegocio
    {
        public static BusEntidad Crear(BusEntidad busEntidad)
        {
            return BusDatos.Crear(busEntidad);
        }
        public static BusEntidad Actualizar(BusEntidad busEntidad)
        {
            return BusDatos.Actualizar(busEntidad);
        }

        public static List<BusEntidad> ListarBuses()
        {
            return BusDatos.ListarBuses();
        }

        public static BusEntidad ObtenerBusPorId(int Id)
        {
            return BusDatos.ObtenerBusPorId(Id);
        }

        public static bool Eliminar(int Id)
        {
            return BusDatos.Eliminar(Id);
        }
    }
}
