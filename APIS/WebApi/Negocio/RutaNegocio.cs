using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class RutaNegocio
    {
        public static RutaEntidad Crear(RutaEntidad rutaEntidad)
        {
            return RutaDatos.Crear(rutaEntidad);
        }
        public static RutaEntidad Actualizar(RutaEntidad rutaEntidad)
        {
            return RutaDatos.Actualizar(rutaEntidad);
        }

        public static List<RutaEntidad> ListarRutas()
        {
            return RutaDatos.ListarRutas();
        }

        public static RutaEntidad ObtenerRutaPorId(int Id)
        {
            return RutaDatos.ObtenerRutaPorId(Id);
        }

        public static bool Eliminar(int Id)
        {
            return RutaDatos.Eliminar(Id);
        }
    }
}
