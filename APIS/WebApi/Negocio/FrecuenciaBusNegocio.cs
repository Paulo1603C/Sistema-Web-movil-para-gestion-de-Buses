using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class FrecuenciaBusNegocio
    {
        public static FrecuenciaBusEntidad Crear(FrecuenciaBusEntidad frecuenciaBusEntidad)
        {
            return FrecuenciaBusDatos.Crear(frecuenciaBusEntidad);
        }
        public static FrecuenciaBusEntidad Actualizar(FrecuenciaBusEntidad frecuenciaBusEntidad)
        {
            return FrecuenciaBusDatos.Actualizar(frecuenciaBusEntidad);
        }

        public static List<FrecuenciaBusEntidad> ListarFrecuenciasBus()
        {
            return FrecuenciaBusDatos.ListarFrecuenciasBus();
        }

        public static FrecuenciaBusEntidad ObtenerFrecuenciaBusPorId(int Id)
        {
            return FrecuenciaBusDatos.ObtenerFrecuenciaBusPorId(Id);
        }

        public static bool Eliminar(int Id)
        {
            return FrecuenciaBusDatos.Eliminar(Id);
        }
        public static bool HabilitarFrecuenciaBus(string IdFrecuencia, string IdUsuario)
        {
            return FrecuenciaBusDatos.HabilitarFrecuenciaBus(IdFrecuencia, IdUsuario);
        }
    }
}
