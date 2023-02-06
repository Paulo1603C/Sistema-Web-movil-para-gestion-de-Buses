using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class FrecuenciaNegocio
    {
        public static FrecuenciaEntidad Crear(FrecuenciaEntidad frecuenciaEntidad)
        {
            return FrecuenciaDatos.Crear(frecuenciaEntidad);
        }
        public static FrecuenciaEntidad Actualizar(FrecuenciaEntidad frecuenciaEntidad)
        {
            return FrecuenciaDatos.Actualizar(frecuenciaEntidad);
        }

        public static List<FrecuenciaEntidad> ListarFrecuencias()
        {
            return FrecuenciaDatos.ListarFrecuencias();
        }

        public static FrecuenciaEntidad ObtenerFrecuenciaPorId(int Id)
        {
            return FrecuenciaDatos.ObtenerFrecuenciaPorId(Id);
        }

        public static bool Eliminar(int Id)
        {
            return FrecuenciaDatos.Eliminar(Id);
        }
        public static bool HabilitarFrecuencia(string IdFrecuencia, string IdUsuario)
        {
            return FrecuenciaDatos.HabilitarFrecuencia(IdFrecuencia, IdUsuario);
        }
    }
}
