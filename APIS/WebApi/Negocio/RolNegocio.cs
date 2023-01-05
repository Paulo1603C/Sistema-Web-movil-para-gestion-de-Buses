using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  static class  RolNegocio
    {
        public static RolEntidad crearRol(RolEntidad rolEntidad)
        {
            return RolDatos.crearRol(rolEntidad);

        }
    }
}
