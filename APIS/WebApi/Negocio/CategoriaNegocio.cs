using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class CategoriaNegocio
    {
        public static CategoriaEntidad Crear(CategoriaEntidad categoriaEntidad)
        {
            return CategoriaDatos.Crear(categoriaEntidad);
        }
        public static CategoriaEntidad Actualizar(CategoriaEntidad categoriaEntidad)
        {
            return CategoriaDatos.Actualizar(categoriaEntidad);
        }

        public static List<CategoriaEntidad> ListarCategorias()
        {
            return CategoriaDatos.ListarCategorias();
        }

        public static CategoriaEntidad ObtenerCategoriaPorId(int Id)
        {
            return CategoriaDatos.ObtenerCategoriaPorId(Id);
        }

        public static bool Eliminar(int Id)
        {
            return CategoriaDatos.Eliminar(Id);
        }
    }
}
