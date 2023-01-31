using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class CooperativaNegocio
    {
        public static CooperativaEntidad Crear(CooperativaEntidad cooperativaEntidad)
        {
            return CooperativaDatos.Crear(cooperativaEntidad);
        }
        public static CooperativaEntidad Actualizar(CooperativaEntidad cooperativaEntidad)
        {
            return CooperativaDatos.Actualizar(cooperativaEntidad);
        }
        
        public static List<CooperativaEntidad> ListarCooperativas()
        {
            return CooperativaDatos.ListarCooperativas();
        }
        
        public static CooperativaEntidad ObtenerCooperativaPorId(int Id)
        {
            return CooperativaDatos.ObtenerCooperativaPorId(Id);
        }
        
        public static bool Eliminar(int Id)
        {
            return CooperativaDatos.Eliminar(Id);
        }
    }
}
