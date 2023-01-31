using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class RolNegocio
    {
        public static RolEntidad Crear(RolEntidad rolEntidad)
        {
            return RolDatos.Crear(rolEntidad);
        }
        public static List<RolEntidad> ListarRoles()
        {
            return RolDatos.ListarRoles();
        }
        public static RolEntidad ObtenerRolPorId(int Id)
        {
            return RolDatos.ObtenerRolPorId(Id);
        }
        public static RolEntidad Actualizar(RolEntidad rolEntidad)
        {
            return RolDatos.Actualizar(rolEntidad);
        }
        public static bool Eliminar(int Id)
        {
            return RolDatos.Eliminar(Id);
        }
    }
}
