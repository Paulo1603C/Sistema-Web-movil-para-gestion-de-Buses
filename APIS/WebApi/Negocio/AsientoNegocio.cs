using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class AsientoNegocio
    {
        public static AsientoEntidad Crear(AsientoEntidad asientoEntidad)
        {
            return AsientoDatos.Crear(asientoEntidad);
        }
        public static AsientoEntidad Actualizar(AsientoEntidad asientoEntidad)
        {
            return AsientoDatos.Actualizar(asientoEntidad);
        }

        public static List<AsientoEntidad> ListarAsientos()
        {
            return AsientoDatos.ListarAsientos();
        }

        public static AsientoEntidad ObtenerAsientoPorId(int Id)
        {
            return AsientoDatos.ObtenerAsientoPorId(Id);
        }

        public static bool Eliminar(int Id)
        {
            return AsientoDatos.Eliminar(Id);
        }
    }
}
