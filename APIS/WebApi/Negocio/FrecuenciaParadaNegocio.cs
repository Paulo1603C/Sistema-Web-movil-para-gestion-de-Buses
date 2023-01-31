using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class FrecuenciaParadaNegocio
    {
        public static FrecuenciaParadaEntidad Crear(FrecuenciaParadaEntidad frecuenciaParadaEntidad)
        {
            return FrecuenciaParadaDatos.Crear(frecuenciaParadaEntidad);
        }
        public static FrecuenciaParadaEntidad Actualizar(FrecuenciaParadaEntidad frecuenciaParadaEntidad)
        {
            return FrecuenciaParadaDatos.Actualizar(frecuenciaParadaEntidad);
        }

        public static List<FrecuenciaParadaEntidad> ListarFrecuenciasParada()
        {
            return FrecuenciaParadaDatos.ListarFrecuenciasParada();
        }

        public static FrecuenciaParadaEntidad ObtenerFrecuenciaParadaPorId(int Id)
        {
            return FrecuenciaParadaDatos.ObtenerFrecuenciaParadaPorId(Id);
        }

        public static bool Eliminar(int Id)
        {
            return FrecuenciaParadaDatos.Eliminar(Id);
        }
    }
}
