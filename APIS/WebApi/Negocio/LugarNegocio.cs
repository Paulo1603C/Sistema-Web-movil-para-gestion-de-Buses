using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class LugarNegocio
    {
        public static LugarEntidad Crear(LugarEntidad lugarEntidad)
        {
            return LugarDatos.Crear(lugarEntidad);
        }
        public static LugarEntidad Actualizar(LugarEntidad lugarEntidad)
        {
            return LugarDatos.Actualizar(lugarEntidad);
        }

        public static List<LugarEntidad> ListarLugares()
        {
            return LugarDatos.ListarLugares();
        }

        public static LugarEntidad ObtenerLugarPorId(int Id)
        {
            return LugarDatos.ObtenerLugarPorId(Id);
        }

        public static bool Eliminar(int Id)
        {
            return LugarDatos.Eliminar(Id);
        }
    }
}
